using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using OnlineEventManagementSystem.DAL;
using OnlineEventManagementSystem.Models;

namespace OnlineEventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly eventmanagementsystemdbContext _context;

        public LoginsController(eventmanagementsystemdbContext context)
        {
            _context = context;
        }
        LoginDAL ldal=new LoginDAL();
        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogins()
        {
          if (_context.Logins == null)
          {
              return NotFound();
          }
            return await _context.Logins.ToListAsync();
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
          if (_context.Logins == null)
          {
              return NotFound();
          }
            var login = await _context.Logins.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Logins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.Id)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Logins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
          if (_context.Logins == null)
          {
              return Problem("Entity set 'eventmanagementsystemdbContext.Logins'  is null.");
          }
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogin", new { id = login.Id }, login);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            if (_context.Logins == null)
            {
                return NotFound();
            }
            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginExists(int id)
        {
            return (_context.Logins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [HttpPost("/chkLogin")]
        public async Task<IActionResult> CheckLogin(LoginCheck loginData)
        {
            var log = await _context.Logins
                .FirstOrDefaultAsync(u => u.Username == loginData.Username && u.Password == loginData.Password);

            if (log == null)
            {
                return Unauthorized(); // Return appropriate status code for unsuccessful login
            }

            return Ok(log); // Return user data or success status
        }



        [HttpPost("/saveClientRegister")]
        public async Task<ActionResult<string>> PostCRegister(CRegister cregister)
        {
            if (cregister == null)
            {
                return Problem("Entity set 'eventmanagementsystemdbContext.CRegister'  is null.");
            }
           
            Login lg = new Login(cregister.Username, cregister.Password,1);
            _context.Logins.Add(lg);
            await _context.SaveChangesAsync();

            Address ad = new Address(cregister.HouseNumber, cregister.Area, cregister.City, cregister.Pincode, cregister.State);
            _context.Addresses.Add(ad);
            await _context.SaveChangesAsync();

            Client cl=new Client(cregister.Name, cregister.Email ,cregister.ContactNumber, ad.Id, lg.Id);
            _context.Clients.Add(cl);
            await _context.SaveChangesAsync();
     
            return  Ok("success");
        }


        [HttpPost("/saveBusinessRegister")]
        public async Task<ActionResult<string>> PostBRegister(BRegister bregister)
        {
            if (bregister == null)
            {
                return Problem("Entity set 'eventmanagementsystemdbContext.BRegister'  is null.");
            }

            Login lg = new Login(bregister.Username, bregister.Password, 2);
            _context.Logins.Add(lg);
            await _context.SaveChangesAsync();

            Address ad = new Address(bregister.HouseNumber, bregister.Area, bregister.City, bregister.Pincode, bregister.State);
            _context.Addresses.Add(ad);
            await _context.SaveChangesAsync();

            Business bs = new Business(bregister.Name, bregister.Email, bregister.ContactNumber,bregister.RegistrationNumber,1, lg.Id, ad.Id);
            _context.Businesses.Add(bs);
            await _context.SaveChangesAsync();

            return Ok("success");
        }

    }
}
