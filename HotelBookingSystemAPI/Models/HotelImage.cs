namespace HotelBookingSystemAPI.Models
{
    public class HotelImage
    {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
