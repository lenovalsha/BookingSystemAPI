using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemAPI.Models
{
    public class Admin
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }

        public List<Hotel>? Hotels { get; set; }
        public Admin()
        {
            Hotels = new List<Hotel>();
        }
    }
}
