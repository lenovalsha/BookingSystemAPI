namespace HotelBookingSystemAPI.Models
{
    public class RoomStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Room>? Rooms { get; set; }
        public RoomStatus()
        {
            Rooms = new List<Room>();
        }
    }
}
