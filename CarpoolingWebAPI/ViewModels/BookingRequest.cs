using System.ComponentModel.DataAnnotations;

namespace CarpoolingWebAPI.ViewModels
{
    public class BookingRequest
    {
        public string OfferID { get; set; }
        public string PassengerID { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public int NumOfSeatsBooked { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
