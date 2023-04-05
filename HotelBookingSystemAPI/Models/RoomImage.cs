namespace HotelBookingSystemAPI.Models
{
    public class RoomImage
    {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

    }
}
