using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEventManagementSystem.Models;

namespace OnlineEventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuisnessServicesController : ControllerBase
    {
        private readonly eventmanagementsystemdbContext _context;

        public BuisnessServicesController(eventmanagementsystemdbContext context)
        {
            _context = context;
        }

        // GET: api/BuisnessServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuisnessService>>> GetBuisnessServices()
        {
          if (_context.BuisnessServices == null)
          {
              return NotFound();
          }
            return await _context.BuisnessServices.ToListAsync();
        }

        // GET: api/BuisnessServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuisnessService>> GetBuisnessService(int id)
        {
          if (_context.BuisnessServices == null)
          {
              return NotFound();
          }
            var buisnessService = await _context.BuisnessServices.FindAsync(id);

            if (buisnessService == null)
            {
                return NotFound();
            }

            return buisnessService;
        }

        // PUT: api/BuisnessServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuisnessService(int id, BuisnessService buisnessService)
        {
            if (id != buisnessService.Id)
            {
                return BadRequest();
            }

            _context.Entry(buisnessService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuisnessServiceExists(id))
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

        // POST: api/BuisnessServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuisnessService>> PostBuisnessService(BuisnessService buisnessService)
        {
          if (_context.BuisnessServices == null)
          {
              return Problem("Entity set 'eventmanagementsystemdbContext.BuisnessServices'  is null.");
          }
            _context.BuisnessServices.Add(buisnessService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuisnessService", new { id = buisnessService.Id }, buisnessService);
        }

        // DELETE: api/BuisnessServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuisnessService(int id)
        {
            if (_context.BuisnessServices == null)
            {
                return NotFound();
            }
            var buisnessService = await _context.BuisnessServices.FindAsync(id);
            if (buisnessService == null)
            {
                return NotFound();
            }

            _context.BuisnessServices.Remove(buisnessService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuisnessServiceExists(int id)
        {
            return (_context.BuisnessServices?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("/getbservicebyId")]
        public async Task<List<BuisnessService>> getBusinessById(int id)
        {
            List<BuisnessService> bss = new List<BuisnessService>();
            bss= await (from B in _context.BuisnessServices where(B.ServicesId==id) select B).ToListAsync();
            return bss;
        }
    }
}
