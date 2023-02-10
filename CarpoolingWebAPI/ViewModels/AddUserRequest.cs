namespace CarpoolingWebAPI.ViewModels
{
    public class AddUserRequest
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string OffersMade { get; set; }
        public string BookingsMade { get; set; }
    }
}
