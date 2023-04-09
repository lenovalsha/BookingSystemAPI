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
    public class ReservationStatusController : ControllerBase
    {
        private readonly DataContext _context;

        public ReservationStatusController(DataContext context)
        {
            _context = context;
        }
        // GET: api/ReservationStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationStatus>>> GetReservationStatuses()
        {
          if (_context.ReservationStatuses == null)
          {
              return NotFound();
          }
            return await _context.ReservationStatuses.ToListAsync();
        }

        // GET: api/ReservationStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationStatus>> GetReservationStatus(int id)
        {
          if (_context.ReservationStatuses == null)
          {
              return NotFound();
          }
            var reservationStatus = await _context.ReservationStatuses.FindAsync(id);

            if (reservationStatus == null)
            {
                return NotFound();
            }

            return reservationStatus;
        }

        // PUT: api/ReservationStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationStatus(int id, ReservationStatus reservationStatus)
        {
            if (id != reservationStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservationStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationStatusExists(id))
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

        // POST: api/ReservationStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservationStatus>> PostReservationStatus(ReservationStatus reservationStatus)
        {
          if (_context.ReservationStatuses == null)
          {
              return Problem("Entity set 'DataContext.ReservationStatuses'  is null.");
          }
            _context.ReservationStatuses.Add(reservationStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationStatus", new { id = reservationStatus.Id }, reservationStatus);
        }

        // DELETE: api/ReservationStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationStatus(int id)
        {
            if (_context.ReservationStatuses == null)
            {
                return NotFound();
            }
            var reservationStatus = await _context.ReservationStatuses.FindAsync(id);
            if (reservationStatus == null)
            {
                return NotFound();
            }

            _context.ReservationStatuses.Remove(reservationStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationStatusExists(int id)
        {
            return (_context.ReservationStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
