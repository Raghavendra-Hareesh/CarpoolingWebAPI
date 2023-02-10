using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPoolingWebAPI.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public string UserID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set;}
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string OffersMade { get; set; }
        public string BookingsMade { get; set; }
    }
}
