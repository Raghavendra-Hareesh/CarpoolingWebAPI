using CarpoolingWebAPI.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace CarPoolingWebAPI.Models
{
    public class History
    {
        /*public History(Ride ride)
        {
            this.OfferID = ride.OfferID;
            this.DriverID = ride.DriverID;
            this.StartPoint = ride.StartPoint;
            this.EndPoint = ride.EndPoint;
            this.TotalSeats = ride.TotalSeats;
            this.Stops = ride.Stops;
            this.SeatsPerStop = ride.SeatsPerStop;
            this.Date = ride.Date;
            this.Time = ride.Time;
            this.Price = ride.Price;
            this.BookingList = ride.BookingList;
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
