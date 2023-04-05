using System.Reflection.Metadata.Ecma335;

namespace HotelBookingSystemAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int Floor { get; set; }
        public int RoomNumber { get; set; }
        public string Description { get; set; }
        public double BaseRate { get; set; }
        public int? RoomStatusId { get; set; }
        public int? RoomTypeId { get; set; }
        public RoomType? RoomType { get; set; }
        public RoomStatus? RoomStatus { get; set; }

        public List<Payment>? Payments { get; set; }
        public List<Reservation>? RoomsBooked { get; set; }
        public Room()
        {
            Payments = new List<Payment>();
            RoomsBooked = new List<Reservation>();
        }

    }
}
