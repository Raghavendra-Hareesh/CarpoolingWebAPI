using CarPoolingWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CarpoolingWebAPI.ViewModels
{
    public class RideModel
    {
        [Key]
        public string OfferID { get; set; }
        public string DriverID { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string Stops { get; set; }
        public int TotalSeats { get; set; }
        public string SeatsPerStop { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Price { get; set; }
        public string BookingList { get; set; }
    }
}
