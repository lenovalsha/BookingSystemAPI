namespace HotelBookingSystemAPI.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? PositionId { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
