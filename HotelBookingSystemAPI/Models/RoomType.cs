namespace HotelBookingSystemAPI.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Room>? Rooms { get; set; }
        public RoomType()
        {
            Rooms = new List<Room>();
        }
    }
}
