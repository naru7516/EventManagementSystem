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
    public class FeedbackStatusController : ControllerBase
    {
        private readonly eventmanagementsystemdbContext _context;

        public FeedbackStatusController(eventmanagementsystemdbContext context)
        {
            _context = context;
        }

        // GET: api/FeedbackStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackStatus>>> GetFeedbackStatuses()
        {
          if (_context.FeedbackStatuses == null)
          {
              return NotFound();
          }
            return await _context.FeedbackStatuses.ToListAsync();
        }

        // GET: api/FeedbackStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackStatus>> GetFeedbackStatus(int id)
        {
          if (_context.FeedbackStatuses == null)
          {
              return NotFound();
          }
            var feedbackStatus = await _context.FeedbackStatuses.FindAsync(id);

            if (feedbackStatus == null)
            {
                return NotFound();
            }

            return feedbackStatus;
        }

        // PUT: api/FeedbackStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbackStatus(int id, FeedbackStatus feedbackStatus)
        {
            if (id != feedbackStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(feedbackStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackStatusExists(id))
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

        // POST: api/FeedbackStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedbackStatus>> PostFeedbackStatus(FeedbackStatus feedbackStatus)
        {
          if (_context.FeedbackStatuses == null)
          {
              return Problem("Entity set 'eventmanagementsystemdbContext.FeedbackStatuses'  is null.");
          }
            _context.FeedbackStatuses.Add(feedbackStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedbackStatus", new { id = feedbackStatus.Id }, feedbackStatus);
        }

        // DELETE: api/FeedbackStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackStatus(int id)
        {
            if (_context.FeedbackStatuses == null)
            {
                return NotFound();
            }
            var feedbackStatus = await _context.FeedbackStatuses.FindAsync(id);
            if (feedbackStatus == null)
            {
                return NotFound();
            }

            _context.FeedbackStatuses.Remove(feedbackStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbackStatusExists(int id)
        {
            return (_context.FeedbackStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
