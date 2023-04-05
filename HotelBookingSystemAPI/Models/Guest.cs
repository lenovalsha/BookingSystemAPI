namespace HotelBookingSystemAPI.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Phone { get; set; }
        public List<Booking>? Bookings { get; set; }

        public Guest()
        {
            Bookings = new List<Booking>();
        }

    }
}
