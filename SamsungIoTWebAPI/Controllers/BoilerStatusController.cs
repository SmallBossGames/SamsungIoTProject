using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsungIoTWebAPI.Models;
using Shared.Models;
using Shared.Utilities;

namespace SamsungIoTWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoilerStatusController : ControllerBase
    {
        private readonly SamsungIoTWebAPIContext _context;

        public BoilerStatusController(SamsungIoTWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/BoilerStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoilerStatus>>> GetBoilerStatus()
        {
            return await _context.BoilerStatus.ToListAsync();
        }

        // GET: api/BoilerStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoilerStatus>> GetBoilerStatus(long id)
        {
            var boilerStatus = await _context.BoilerStatus.FindAsync(id);

            if (boilerStatus == null)
            {
                return NotFound();
            }

            return boilerStatus;
        }

        // PUT: api/BoilerStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoilerStatus(long id, BoilerStatus boilerStatus)
        {
            if (id != boilerStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(boilerStatus).State = EntityState.Modified;
            boilerStatus.UpdateTime = DateTime.Now;
            boilerStatus.UserId = Constants.defaultUserName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoilerStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BoilerStatus
        [HttpPost]
        public async Task<ActionResult<BoilerStatus>> PostBoilerStatus(BoilerStatus boilerStatus)
        {
            boilerStatus.UpdateTime = DateTime.Now;
            boilerStatus.UserId = Constants.defaultUserName;

            _context.BoilerStatus.Add(boilerStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoilerStatus", new { id = boilerStatus.Id }, boilerStatus);
        }

        // DELETE: api/BoilerStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoilerStatus>> DeleteBoilerStatus(long id)
        {
            var boilerStatus = await _context.BoilerStatus.FindAsync(id);
            if (boilerStatus == null)
            {
                return NotFound();
            }

            _context.BoilerStatus.Remove(boilerStatus);
            await _context.SaveChangesAsync();

            return boilerStatus;
        }

        private bool BoilerStatusExists(long id)
        {
            return _context.BoilerStatus.Any(e => e.Id == id);
        }
    }
}
