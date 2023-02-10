using System.ComponentModel.DataAnnotations;

namespace CarpoolingWebAPI.Models
{
    public class UserLogin
    {
        [Key]
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
