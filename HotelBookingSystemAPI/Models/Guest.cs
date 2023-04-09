
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemAPI.Models
{
    public class Guest
    {
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public List<Reservation>? Reservations { get; set; }

        public Guest()
        {
            Reservations = new List<Reservation>();
        }

    }
}
