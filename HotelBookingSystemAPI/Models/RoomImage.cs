namespace HotelBookingSystemAPI.Models
{
    public class RoomImage
    {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
        public int? RoomNumber { get; set; }
        public Room? Room { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }

    }
}
