namespace HotelBookingSystemAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int? BookingStatusId { get; set; }
        public BookingStatus? BookingStatus { get; set; }

        public List<Reservation>? RoomsBooked { get; set; }
        public Booking()
        {
            RoomsBooked = new List<Reservation>();
        }


    }
}
