using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class Login
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? UserTypeId { get; set; }

    public virtual ICollection<Business> Businesses { get; set; } = new List<Business>();

    public virtual UserType? UserType { get; set; }

    public Login() { }  
    public Login( string username, string password,int user_type_id)
    {
        Username = username;
        Password = password;
        UserTypeId = user_type_id;
    }


}
