using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class Address
{
    public int Id { get; set; }

    public string HouseNumber { get; set; } = null!;

    public string Area { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Pincode { get; set; } = null!;

    public string State { get; set; } = null!;

    public virtual ICollection<Business> Businesses { get; set; } = new List<Business>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public Address() { 
    
    
    }
    public Address( string houseNumber, string area, string city, string pincode, string state)
    {
        HouseNumber = houseNumber;
        Area = area;
        City = city;
        Pincode = pincode;
        State = state;
       
    }
}
