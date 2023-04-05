namespace HotelBookingSystemAPI.Models
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Payment>? Payments { get; set; }
        public PaymentStatus()
        {
            Payments = new List<Payment>();
        }
    }
}
