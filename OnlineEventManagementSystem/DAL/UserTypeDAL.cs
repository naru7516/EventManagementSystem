using MySqlConnector;
using OnlineEventManagementSystem.Models;
using System.Data;

namespace OnlineEventManagementSystem.DAL
{
    public class UserTypeDAL
    {
        static string constr = @"server=localhost;userid=root;password=root;database=eventmanagementsystemdb";

        public static List<UserType> GetUserTypes()
        {
            List<UserType> clist = new List<UserType>();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandText = "select * from user_type;";
                    //  cmd.Parameters.AddWithValue("@cardNo", id);
                    MySqlDataReader rd = cmd.ExecuteReader();

                    Console.WriteLine("\n\n");
                    while (rd.Read())
                    {
                        UserType r = new UserType();
                        {

                            r.Id = rd.GetInt32(0);
                            r.UserType1 = rd.GetString(1);

                        }
                        clist.Add(r);
                    }

                    con.Close();
                }
                return clist;

            }

        }
    }
}
