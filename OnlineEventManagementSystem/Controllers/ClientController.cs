using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEventManagementSystem.DAL;
using OnlineEventManagementSystem.Models;
using System.Configuration;

namespace OnlineEventManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly eventmanagementsystemdbContext _context;
        public ClientController(eventmanagementsystemdbContext context)
        {
            _context = context;
        }
       


        ClientDAL cdl = new ClientDAL();

        [HttpGet]
        [Route("api/Client/getAll")]
        public async  Task<IEnumerable<Client>> GetAllClientss()
        {
            return await cdl.GetAllClients();
        }



        [HttpPost]
        [Route("api/Client/addClient")]
        public Task<Int32> AddClients(Client cl)
        {
            return cdl.AddClientAsync(cl);
        }


        [HttpGet]
        [Route("api/Client/details/{id}")]
        public Task<Client> Details(int id)
        {
            return cdl.GetClientsData(id);
        }



        [HttpDelete]
        [Route("api/Client/delete/{id}")]
        public Task<Int32> DeleteAsync(int id)
        {
            return cdl.DeleteClient(id);
        }

        [HttpPut]
        [Route("api/Client/update")]
        public async Task UpdateAsync(Client cl)
        {
            this._context.Clients.Update(cl);
            await this._context.SaveChangesAsync();
        }

        [HttpGet]
        [Route("api/Client/GetClientssList")]
        public async Task<IEnumerable<Client>> Details()
        {
            return await cdl.GetClientList();
        }


        
    }
}
