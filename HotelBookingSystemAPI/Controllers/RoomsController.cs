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
    public class RoomsController : ControllerBase
    {
        private readonly DataContext _context;

        public RoomsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int? id)
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }
        // GET: api/Rooms/HotelId/5
        [HttpGet("hotelId/{hotelid}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsByHotelId(int? hotelid)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var room = await _context.Rooms.Where(r => r.HotelId == hotelid).ToListAsync();

            if (room == null)
            {
                return NotFound();
            }
            return room;
        }
        // GET: api/Rooms/HotelId/51
        [HttpGet("hotelId/{hotelId}/arrivaldate/{checkinDate}/departuredate/{checkoutdate}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAvailableRooms(DateTime checkoutDate, DateTime checkinDate, int hotelId)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var overlappingReservations = await _context.Reservations.Where(r => r.ArrivalDate < checkoutDate && r.DepartureDate > checkinDate && r.HotelId == hotelId).ToListAsync();
            var bookedRoomNumbers = overlappingReservations.Select(r => r.RoomNumber).ToList();
            var availableRooms = await _context.Rooms.Where(r =>r.HotelId == hotelId && !bookedRoomNumbers.Contains(r.RoomNumber)).ToListAsync();
            if (availableRooms == null)
            {
                return NotFound();
            }
            return availableRooms;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int? id, Room room)
        {
            if (id != room.HotelId)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
          if (_context.Rooms == null)
          {
              return Problem("Entity set 'DataContext.Rooms'  is null.");
          }
            _context.Rooms.Add(room);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomExists(room.HotelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoom", new { id = room.HotelId }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int? id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int? id)
        {
            return (_context.Rooms?.Any(e => e.HotelId == id)).GetValueOrDefault();
        }
    }
}
