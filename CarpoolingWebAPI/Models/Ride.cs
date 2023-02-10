using CarpoolingWebAPI.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace CarPoolingWebAPI.Models
{
    public class Ride
    {
        /*public Ride(RideModel rideModel)
        {
            this.OfferID = rideModel.OfferID;
            this.DriverID = rideModel.DriverID;
            this.StartPoint = rideModel.StartPoint;
            this.EndPoint = rideModel.EndPoint;
            this.TotalSeats = rideModel.TotalSeats;
            this.SeatsPerStop = rideModel.SeatsPerStop;
            this.Date = rideModel.Date;
            this.Time = rideModel.Time;
            this.Price = rideModel.Price;
            this.BookingList = rideModel.BookingList;
        }*/

        [Key]
        public string OfferID { get; set; }        
        public string DriverID { get; set;}        
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string Stops { get; set; }
        public int TotalSeats { get; set; }
        public string SeatsPerStop { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Price { get; set;}
        public string BookingList { get; set; }
    }
}
