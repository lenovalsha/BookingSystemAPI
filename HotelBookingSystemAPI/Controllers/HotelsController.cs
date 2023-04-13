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
    public class HotelsController : ControllerBase
    {
        private readonly DataContext _context;

        public HotelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
          if (_context.Hotels == null)
          {
              return NotFound();
          }
            return await _context.Hotels.ToListAsync();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
          if (_context.Hotels == null)
          {
              return NotFound();
          }
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }
        // GET: api/Hotels?adminusername=a
        [HttpGet("adminusername/{name}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelByAdmin(string name)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotels.Where(t => t.AdminUsername == name).ToListAsync();
            if (hotel.Count == 0)
            {
                return NotFound();
            }
            return hotel;
        }
        // GET: api/Hotels/province/ab
        [HttpGet("province/{prov}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelByProvince(string prov)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotels.Where(t => t.Province == prov).ToListAsync();
            if (hotel.Count == 0)
            {
                return NotFound();
            }

            return hotel;
        }
        // GET: api/Hotels/province/ab
        [HttpGet("arrivaldate/{checkinDate}/departuredate/{checkoutdate}/province/{prov}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelByProvince(string prov,DateTime checkoutDate,DateTime checkinDate)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }

            //get the rooms that have available in the date
            var overlappingReservations = await _context.Reservations.Where(r => r.ArrivalDate < checkoutDate && r.DepartureDate > checkinDate).ToListAsync();
            var bookedRoomNumbers = overlappingReservations.Select(r => r.RoomNumber).ToList();
            var availableRooms = await _context.Rooms.Where(r => !bookedRoomNumbers.Contains(r.RoomNumber)).ToListAsync();

            var filter = await _context.Hotels.Include(a=>a.Reservations).ToListAsync();
            var hotels = new List<Hotel>();
            var rooms = new List<Room>();
            foreach (Hotel h in filter)
            {
                if(h.Province == prov)
                {
                foreach (Room room in availableRooms)
                {
                    if(room.HotelId == h.Id)
                    {
                        hotels.Add(h);
                    }
                }

                }
               
            }
            return hotels;

        }
        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
          if (_context.Hotels == null)
          {
              return Problem("Entity set 'DataContext.Hotels'  is null.");
          }
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(int id)
        {
            return (_context.Hotels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
