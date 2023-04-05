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
    public class PaymentStatusController : ControllerBase
    {
        private readonly DataContext _context;

        public PaymentStatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PaymentStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentStatus>>> GetPaymentStatuses()
        {
          if (_context.PaymentStatuses == null)
          {
              return NotFound();
          }
            return await _context.PaymentStatuses.ToListAsync();
        }

        // GET: api/PaymentStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentStatus>> GetPaymentStatus(int id)
        {
          if (_context.PaymentStatuses == null)
          {
              return NotFound();
          }
            var paymentStatus = await _context.PaymentStatuses.FindAsync(id);

            if (paymentStatus == null)
            {
                return NotFound();
            }

            return paymentStatus;
        }

        // PUT: api/PaymentStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentStatus(int id, PaymentStatus paymentStatus)
        {
            if (id != paymentStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentStatusExists(id))
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

        // POST: api/PaymentStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentStatus>> PostPaymentStatus(PaymentStatus paymentStatus)
        {
          if (_context.PaymentStatuses == null)
          {
              return Problem("Entity set 'DataContext.PaymentStatuses'  is null.");
          }
            _context.PaymentStatuses.Add(paymentStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentStatus", new { id = paymentStatus.Id }, paymentStatus);
        }

        // DELETE: api/PaymentStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentStatus(int id)
        {
            if (_context.PaymentStatuses == null)
            {
                return NotFound();
            }
            var paymentStatus = await _context.PaymentStatuses.FindAsync(id);
            if (paymentStatus == null)
            {
                return NotFound();
            }

            _context.PaymentStatuses.Remove(paymentStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentStatusExists(int id)
        {
            return (_context.PaymentStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
