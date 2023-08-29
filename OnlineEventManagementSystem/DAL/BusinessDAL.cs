using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using OnlineEventManagementSystem.Models;

namespace OnlineEventManagementSystem.DAL
{
    public class BusinessDAL
    {

        static string constr = @"server=localhost;userid=root;password=root;database=eventmanagementsystemdb";

        public static List<Business> GetBusinesses() 
        {
            List<Business> alist = new List<Business>();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandText = "select * from Businesses;";

                    MySqlDataReader rd = cmd.ExecuteReader();

                    Console.WriteLine("\n\n");
                    while (rd.Read())
                    {
                        Business a = new Business();
                        {

                            a.Id = rd.GetInt32(0);
                            a.Name = rd.GetString(1);
                            a.Email = rd.GetString(2);
                            a.ContactNumber = rd.GetString(3);
                            a.RegistrationNumber = rd.GetString(4);
                            a.WorkingStatus=rd.GetSByte(5);
                            a.LoginId = rd.GetInt32(6);
                            a.AddressId = rd.GetInt32(7);
                           

                        }
                        alist.Add(a);
                    }

                    con.Close();
                }
                return alist;

            }

        }
        eventmanagementsystemdbContext db = new eventmanagementsystemdbContext();


        public IEnumerable<Business> GetAllBusiness()
        {
            try
            {
                return db.Businesses.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Business record     
        public async Task<Int32> AddBusinessAsync(Business business)
        {
            
            try
            {
                db.Businesses.AddAsync(business);
                db.SaveChangesAsync();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Int32> UpdateBusiness(Business business)
        {
            try
            {
                db.Entry(business).State = EntityState.Modified;
                db.SaveChangesAsync();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Business    
        public async Task<Business> GetBusinessData(int id)
        {
            try
            {
                Business business = db.Businesses.Find(id);
                return business;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Business    
        public async Task<Int32> DeleteBusiness(int id)
        {
            try
            {
                Business bs = db.Businesses.Find(id);
                db.Businesses.Remove(bs);
                db.SaveChangesAsync();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Business>> GetBusinessList()
        {
            List<Business> businesses = new List<Business>();
            businesses = await(from BusinessList in db.Businesses select BusinessList).ToListAsync();

            return businesses;
        }

    }
}
