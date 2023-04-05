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
    public class BookingStatusController : ControllerBase
    {
        private readonly DataContext _context;

        public BookingStatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BookingStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingStatus>>> GetBookingStatuses()
        {
          if (_context.BookingStatuses == null)
          {
              return NotFound();
          }
            return await _context.BookingStatuses.ToListAsync();
        }

        // GET: api/BookingStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingStatus>> GetBookingStatus(int id)
        {
          if (_context.BookingStatuses == null)
          {
              return NotFound();
          }
            var bookingStatus = await _context.BookingStatuses.FindAsync(id);

            if (bookingStatus == null)
            {
                return NotFound();
            }

            return bookingStatus;
        }

        // PUT: api/BookingStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingStatus(int id, BookingStatus bookingStatus)
        {
            if (id != bookingStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingStatusExists(id))
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

        // POST: api/BookingStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingStatus>> PostBookingStatus(BookingStatus bookingStatus)
        {
          if (_context.BookingStatuses == null)
          {
              return Problem("Entity set 'DataContext.BookingStatuses'  is null.");
          }
            _context.BookingStatuses.Add(bookingStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingStatus", new { id = bookingStatus.Id }, bookingStatus);
        }

        // DELETE: api/BookingStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingStatus(int id)
        {
            if (_context.BookingStatuses == null)
            {
                return NotFound();
            }
            var bookingStatus = await _context.BookingStatuses.FindAsync(id);
            if (bookingStatus == null)
            {
                return NotFound();
            }

            _context.BookingStatuses.Remove(bookingStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingStatusExists(int id)
        {
            return (_context.BookingStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
