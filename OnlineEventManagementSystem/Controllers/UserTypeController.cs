using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEventManagementSystem.DAL;
using OnlineEventManagementSystem.Models;

namespace OnlineEventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {

        private readonly eventmanagementsystemdbContext _context;
        public UserTypeController(eventmanagementsystemdbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserType>>> GetUserTypes()     {
            List<UserType> user = UserTypeDAL.GetUserTypes();
            return Ok(user);
            //return Ok(await _context.Clients.ToListAsync());
        }
    }
}
