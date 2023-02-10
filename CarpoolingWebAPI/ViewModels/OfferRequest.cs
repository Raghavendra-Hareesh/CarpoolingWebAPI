using System.ComponentModel.DataAnnotations;

namespace CarpoolingWebAPI.ViewModels
{
    public class OfferRequest
    {        
        public string DriverID { get; set; }
        public int SeatsAvailable { get; set; }       
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string Stops { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Price { get; set; }
    }
}
