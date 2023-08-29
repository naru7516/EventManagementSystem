namespace OnlineEventManagementSystem.Models
{
    public class BRegister
    {

        public int Id { get; set; }
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public sbyte WorkingStatus { get; set; } = 1;

        public string HouseNumber { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Pincode { get; set; } = null!;
        public string State { get; set; } = null!;
        public int UserTypeId { get; set; } = 1;
        public Address ads;
        public Login log;
        public Business bs;


        public BRegister()
        {
            ads = new Address(HouseNumber, Area, City, Pincode, State);
            log = new Login(Username, Password, UserTypeId);
            bs = new Business(Name, Email, ContactNumber,RegistrationNumber,WorkingStatus, ads.Id, log.Id);

        }
    }
}
