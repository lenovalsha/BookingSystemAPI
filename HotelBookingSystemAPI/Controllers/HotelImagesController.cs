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
    public class HotelImagesController : ControllerBase
    {
        private readonly DataContext _context;

        public HotelImagesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/HotelImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelImage>>> GetHotelImages()
        {
          if (_context.HotelImages == null)
          {
              return NotFound();
          }
            return await _context.HotelImages.ToListAsync();
        }

        // GET: api/HotelImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelImage>> GetHotelImage(int id)
        {
          if (_context.HotelImages == null)
          {
              return NotFound();
          }
            var hotelImage = await _context.HotelImages.FindAsync(id);

            if (hotelImage == null)
            {
                return NotFound();
            }

            return hotelImage;
        }
        // GET: api/HotelImages/HotelId/5
        [HttpGet("hotelId/{hotelid}")]
        public async Task<ActionResult<byte[]>> GetHotelImagebyHotel(int hotelid)
        {
            if (_context.HotelImages == null)
            {
                return NotFound();
            }
            var hotelImage = await _context.HotelImages.Where(i => i.HotelId == hotelid).Select(i => i.Image).FirstOrDefaultAsync();

            if (hotelImage == null)
            {
                return NotFound();
            }

            return hotelImage;
        }
        // PUT: api/HotelImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelImage(int id, HotelImage hotelImage)
        {
            if (id != hotelImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelImageExists(id))
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

        // POST: api/HotelImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelImage>> PostHotelImage(HotelImage hotelImage)
        {
          if (_context.HotelImages == null)
          {
              return Problem("Entity set 'DataContext.HotelImages'  is null.");
          }
            _context.HotelImages.Add(hotelImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelImage", new { id = hotelImage.Id }, hotelImage);
        }

        // DELETE: api/HotelImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelImage(int id)
        {
            if (_context.HotelImages == null)
            {
                return NotFound();
            }
            var hotelImage = await _context.HotelImages.FindAsync(id);
            if (hotelImage == null)
            {
                return NotFound();
            }

            _context.HotelImages.Remove(hotelImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelImageExists(int id)
        {
            return (_context.HotelImages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
