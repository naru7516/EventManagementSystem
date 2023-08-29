using System;
using System.Collections.Generic;

namespace OnlineEventManagementSystem.Models;

public partial class Business
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string RegistrationNumber { get; set; } = null!;

    public sbyte WorkingStatus { get; set; } = 1;

    public int? AddressId { get; set; }

    public int? LoginId { get; set; }


    public virtual Address? Address { get; set; }

    public virtual ICollection<BuisnessService> BuisnessServices { get; set; } = new List<BuisnessService>();

    public virtual Login? Login { get; set; }
    public Business() { }

    public Business( string name, string email, string contactNumber, string registrationNumber, sbyte workingStatus, int? loginId, int? addressId)
    {
        
      this. Name = name;
       this. Email = email;
        this.ContactNumber = contactNumber;
        this.RegistrationNumber = registrationNumber;
        this.WorkingStatus = workingStatus;
       this.LoginId = loginId;
        this.AddressId = addressId;
      
    }
}
