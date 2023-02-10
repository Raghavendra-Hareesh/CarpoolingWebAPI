using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPoolingWebAPI.Models
{
    [Table("Bookings")]
    public class Booking
    {
        [Key]
        public string BookingID { get; set; }
        public string OfferID { get; set; }
        public string DriverID { get; set; }
        public string PassengerID { get; set; }
        public int NumberOfSeatsBooked { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
    }
}


/*
 var booking = new Bookings()
            {
                BookingID = new Guid(),
                FromPlace = bookARideRequest.FromPlace,
                ToPlace = bookARideRequest.ToPlace,                
                NumberOfSeatsBooked = bookARideRequest.SeatsRequired;
            }
 
 */