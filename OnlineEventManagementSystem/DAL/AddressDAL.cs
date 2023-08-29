using MySqlConnector;
using OnlineEventManagementSystem.Models;

namespace OnlineEventManagementSystem.DAL
{
    public class AddressDAL
    {

        static string constr = @"server=localhost;userid=root;password=root;database=eventmanagementsystemdb";

        public static List<Address> GetAddresses()
        {
            List<Address> alist = new List<Address>();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandText = "select * from address;";
                    //  cmd.Parameters.AddWithValue("@cardNo", id);
                    MySqlDataReader rd = cmd.ExecuteReader();

                    Console.WriteLine("\n\n");
                    while (rd.Read())
                    {
                        Address a = new Address();
                        {

                            a.Id = rd.GetInt32(0);
                            a.HouseNumber= rd.GetString(1);
                            a.Area=rd.GetString(2); 
                            a.City= rd.GetString(3);
                            a.Pincode= rd.GetString(4);
                            a.State= rd.GetString(5);

                        }
                        alist.Add(a);
                    }

                    con.Close();
                }
                return alist;

            }

        }
    }
}
