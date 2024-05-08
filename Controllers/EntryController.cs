using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using perkmaker_backend.Dtos;
using perkmaker_backend;
using perkmaker_backend.Models;
using System.Runtime.InteropServices;
using AutoMapper;

namespace perkmaker_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly PerkmakerContext _db;
        private readonly IMapper _mapper;

        public EntryController(PerkmakerContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var all = await _db.Entries.Include(e => e.User).ToListAsync();
            return Ok(_mapper.Map<List<EntryDto>>(all));
        }

        [HttpGet("{guid:Guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            var entry = await _db.Entries.FirstOrDefaultAsync(e => e.Guid == guid);
            if (entry is null) return NotFound();
            return Ok(entry);
        }

        [Authorize]
        [HttpPost("create/survivor")]
        public async Task<IActionResult> CreateSurvivor([FromBody] SurvivorCreateDto entry)
        {
            var survivor = new Survivor(entry.Name, entry.Description, entry.Image, entry.Perks);
            await _db.Entries.AddAsync(new SurvivorEntry(entry.Header, survivor, await _db.Users.FirstOrDefaultAsync(a => a.Username == HttpContext.User.Identity!.Name)));
            await _db.SaveChangesAsync();
            return Ok();
        }

        [Authorize]
        [HttpPost("create/killer")]
        public async Task<IActionResult> CreateKiller([FromBody] KillerCreateDto entry)
        {
            var killer = new Killer(entry.Name, entry.Description, entry.Image, entry.Perks, entry.KillerPower);
            await _db.Entries.AddAsync(new KillerEntry(entry.Header, killer, await _db.Users.FirstOrDefaultAsync(a => a.Username == HttpContext.User.Identity!.Name)));
            await _db.SaveChangesAsync();
            return Ok();
        }

        [Authorize]
        [HttpPost("create/perk")]
        public async Task<IActionResult> CreatePerk([FromBody] PerkCreateDto entry)
        {
            await _db.Entries.AddAsync(new PerksEntry(entry.Header, entry.Perks, await _db.Users.FirstOrDefaultAsync(a => a.Username == HttpContext.User.Identity!.Name)));
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
