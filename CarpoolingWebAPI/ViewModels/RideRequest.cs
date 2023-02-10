namespace CarpoolingWebAPI.ViewModels
{
    public class RideRequest
    {
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int SeatsRequired { get; set; }
    }
}
