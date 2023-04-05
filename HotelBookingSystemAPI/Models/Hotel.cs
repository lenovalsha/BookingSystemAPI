namespace HotelBookingSystemAPI.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? AdminUsername { get; set; }
        public Admin? Admin { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Phone { get; set; }
        public List<Room>? Rooms { get; set; }
        public List<Booking>? Bookings { get; set; }
        public List<HotelImage>? HotelImages { get; set; }
        public List<Staff>? Staffs { get; set; }



        public Hotel()
        {
            Rooms = new List<Room>();
            Bookings = new List<Booking>();
            HotelImages = new List<HotelImage>();
            Staffs = new List<Staff>();
        }

    }
}
