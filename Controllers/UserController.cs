using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using perkmaker_backend.Dtos;
using perkmaker_backend.Models;
using System.Security.Claims;

namespace perkmaker_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly PerkmakerContext _db;

        public UserController(PerkmakerContext db)
        {
            _db = db;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto user)
        {
            if (await _db.Users.AnyAsync(u => u.Username == user.Username)) return BadRequest("Username already exists");
            if (await _db.Users.AnyAsync(u => u.Email == user.Email)) return BadRequest("Email already exists");

            await _db.Users.AddAsync(new User(user.Username, user.Password, user.Email));
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto user)
        {
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    };
            var claimsIdentity = new ClaimsIdentity(
                claims,
                Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(3),
            };

            await HttpContext.SignInAsync(
                Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return Ok(await _db.Users.FirstOrDefaultAsync(a => a.Username == HttpContext.User.Identity!.Name)); ;
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var authenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
            if (!authenticated) return Unauthorized();
            else
                return Ok(await _db.Users.FirstOrDefaultAsync(a => a.Username == HttpContext.User.Identity!.Name));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Users.ToListAsync());
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _db.Users.FirstOrDefaultAsync(a => a.Username == username);
            if (user is null) return NotFound();
            return Ok(user);
        }
    }
}
