using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystemAPI.Data;
using HotelBookingSystemAPI.Models;

namespace HotelBookingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomStatusController : ControllerBase
    {
        private readonly DataContext _context;

        public RoomStatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RoomStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomStatus>>> GetRoomStatus()
        {
          if (_context.RoomStatus == null)
          {
              return NotFound();
          }
            return await _context.RoomStatus.ToListAsync();
        }
        // GET: api/RoomStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomStatus>> GetRoomStatus(int id)
        {
          if (_context.RoomStatus == null)
          {
              return NotFound();
          }
            var roomStatus = await _context.RoomStatus.FindAsync(id);

            if (roomStatus == null)
            {
                return NotFound();
            }

            return roomStatus;
        }

        // PUT: api/RoomStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomStatus(int id, RoomStatus roomStatus)
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomStatus>> PostRoomStatus(RoomStatus roomStatus)
        {
          if (_context.RoomStatus == null)
          {
              return Problem("Entity set 'DataContext.RoomStatus'  is null.");
          }
            _context.RoomStatus.Add(roomStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomStatus", new { id = roomStatus.Id }, roomStatus);
        }

        // DELETE: api/RoomStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomStatus(int id)
        {
            if (_context.RoomStatus == null)
            {
                return NotFound();
            }
            var roomStatus = await _context.RoomStatus.FindAsync(id);
            if (roomStatus == null)
            {
                return NotFound();
            }

            _context.RoomStatus.Remove(roomStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomStatusExists(int id)
        {
            return (_context.RoomStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
