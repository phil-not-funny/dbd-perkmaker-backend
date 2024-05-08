using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using perkamker_backend.Dtos;
using perkmaker_backend;
using perkmaker_backend.Models;
using System.Runtime.InteropServices;

namespace perkamker_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly PerkmakerContext _db;

        public EntryController(PerkmakerContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.Entries.ToListAsync());
        }

        [HttpGet("{guid:Guid}")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            var entry = await _db.Entries.FirstOrDefaultAsync(e => e.Guid == guid);
            if (entry is null) return NotFound();
            return Ok(entry);
        }

        [HttpPost("create/survivor")]
        public async Task<IActionResult> CreateSurvivor([FromBody] SurvivorCreateDto entry)
        {
            var survivor = new Survivor(entry.Name, entry.Description, entry.Image, entry.Perks);
            await _db.Entries.AddAsync(new SurvivorEntry(entry.Header, survivor));
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("create/killer")]
        public async Task<IActionResult> CreateKiller([FromBody] KillerCreateDto entry)
        {
            var killer = new Killer(entry.Name, entry.Description, entry.Image, entry.Perks, entry.KillerPower);
            await _db.Entries.AddAsync(new KillerEntry(entry.Header, killer));
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("create/perk")]
        public async Task<IActionResult> CreatePerk([FromBody] PerkCreateDto entry)
        {
            await _db.Entries.AddAsync(new PerksEntry(entry.Header, entry.Perks));
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
