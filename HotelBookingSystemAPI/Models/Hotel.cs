namespace HotelBookingSystemAPI.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? AdminUsername { get; set; }
        public Admin? Admin { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postal { get; set; }
        public byte[] Image { get; set; }
        public string Phone { get; set; }
        public List<Room>? Rooms { get; set; }
        public List<Reservation>? Reservations { get; set; }
        public List<HotelImage>? HotelImages { get; set; }
        public List<Staff>? Staffs { get; set; }
        public List<RoomImage>? RoomImages { get; set; }





        public Hotel()
        {
            Rooms = new List<Room>();
            Reservations = new List<Reservation>();
            HotelImages = new List<HotelImage>();
            Staffs = new List<Staff>();
            RoomImages = new List<RoomImage>();
        }

    }
}
