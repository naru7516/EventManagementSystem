using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using OnlineEventManagementSystem.Models;

namespace OnlineEventManagementSystem.DAL
{
    public class LoginDAL
    {
        eventmanagementsystemdbContext db = new eventmanagementsystemdbContext();

        public IEnumerable<Login> GetLogin(LoginCheck check)
        {
            List<Login> logs = new List<Login>()  ;
         //   Repository<Login> lrepo=new Repository<Login>();
         var l=from logins in logs where (logins.Username == check.Username && logins.Password == check.Password) select logins;
        return logs;
        }
    }
}
