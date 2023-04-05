namespace HotelBookingSystemAPI.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Staff>? Staffs { get; set; }
        public Position()
        {
            Staffs = new List<Staff>();
        }
    }
}
