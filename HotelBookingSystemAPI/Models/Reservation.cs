using System.Security.Principal;

namespace HotelBookingSystemAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        public int? BookingId { get; set; }
        public Booking? Booking { get; set; }
        public double Rate { get; set; }
        public int Chidren { get; set; }
        public int Adults { get; set; }
        public int? ReservationStatusId { get; set; }
        public ReservationStatus? ReservationStatus { get; set; }


    }
}
