using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsungIoTWebAPI.Models;
using Shared.Models;

namespace SamsungIoTWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomStatusController : ControllerBase
    {
        private readonly SamsungIoTWebAPIContext _context;

        public RoomStatusController(SamsungIoTWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/RoomStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomStatus>>> GetRoomStatus()
        {
            return await _context.RoomStatus.ToListAsync();
        }

        // GET: api/RoomStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomStatus>> GetRoomStatus(long id)
        {
            var roomStatus = await _context.RoomStatus.FindAsync(id);

            if (roomStatus == null)
            {
                return NotFound();
            }

            return roomStatus;
        }

        // PUT: api/RoomStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomStatus(long id, RoomStatus roomStatus)
        {
            if (id != roomStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomStatusExists(id))
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

        // POST: api/RoomStatus
        [HttpPost]
        public async Task<ActionResult<RoomStatus>> PostRoomStatus(RoomStatus roomStatus)
        {
            _context.RoomStatus.Add(roomStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomStatus", new { id = roomStatus.Id }, roomStatus);
        }

        // DELETE: api/RoomStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomStatus>> DeleteRoomStatus(long id)
        {
            var roomStatus = await _context.RoomStatus.FindAsync(id);
            if (roomStatus == null)
            {
                return NotFound();
            }

            _context.RoomStatus.Remove(roomStatus);
            await _context.SaveChangesAsync();

            return roomStatus;
        }

        private bool RoomStatusExists(long id)
        {
            return _context.RoomStatus.Any(e => e.Id == id);
        }
    }
}
