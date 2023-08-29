namespace OnlineEventManagementSystem.Models
{
    public class CRegister
    {
        public int Id { get; set; }
      public  string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string HouseNumber { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Pincode { get; set; } = null!;
        public string State { get; set; } = null!;
        public int UserTypeId { get; set; } = 1;
        public Address ads;
        public Login log;
        public Client clt;

        
        public CRegister()
        {
         ads = new Address(HouseNumber, Area, City, Pincode, State);
         log=new Login(Username,Password,UserTypeId);
            clt = new Client(Name, Email, ContactNumber, ads.Id, log.Id);

    }

    }
}
