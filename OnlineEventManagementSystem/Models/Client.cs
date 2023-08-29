using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public int? AddressId { get; set; }

    public int? LoginId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public Client() { } 

    public Client( string name, string email, string contactNumber, int? addressId, int? loginId)
    {
        
        this.Name = name;
        this.Email = email;
       this.ContactNumber = contactNumber;
        this.AddressId = addressId;
        this.LoginId = loginId;
     
    }
}
