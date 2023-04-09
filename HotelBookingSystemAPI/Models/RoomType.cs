using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemAPI.Models
{
    public class RoomType
    {
        [Key]
        public string Name { get; set; }
        public List<Room>? Rooms { get; set; }
        public RoomType()
        {
            Rooms = new List<Room>();
        }
    }
}
