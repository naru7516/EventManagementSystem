using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using OnlineEventManagementSystem.Models;

namespace OnlineEventManagementSystem.DAL
{
    public class ClientDAL
    {
        eventmanagementsystemdbContext db = new eventmanagementsystemdbContext();


        public async Task<IEnumerable<Client>> GetAllClients()
        {
            try
            {
                return await db.Clients.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Business record     
        public async Task<Int32> AddClientAsync(Client client)
        {

            try
            {
                db.Clients.AddAsync(client);
                db.SaveChangesAsync();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Int32> UpdateClient(Client client)
        {
            try
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChangesAsync();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Business    
        public async Task<Client> GetClientsData(int id)
        {
            try
            {
                Client client = db.Clients.Find(id);
                return  client;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Business    
        public async Task<Int32> DeleteClient(int id)
        {
            try
            {
                Client cs = db.Clients.Find(id);
                db.Clients.Remove(cs);
                db.SaveChangesAsync();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Client>> GetClientList()
        {
            List<Client> clientss = new List<Client>();
            clientss = await (from ClientList in db.Clients select ClientList).ToListAsync();

            return clientss;
        }

    
}
}
