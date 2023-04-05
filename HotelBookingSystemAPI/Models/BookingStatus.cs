namespace HotelBookingSystemAPI.Models
{
    public class BookingStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Booking>? Bookings { get; set; }
        public BookingStatus()
        {
            Bookings = new List<Booking>();
        }
    }
}
