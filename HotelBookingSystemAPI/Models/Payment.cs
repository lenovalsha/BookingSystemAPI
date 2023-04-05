namespace HotelBookingSystemAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        public DateTime Date { get; set; }
        public int? PaymentTypeId { get; set; }
        public PaymentType? PaymentType { get; set; }
        public int? PaymentStatusId { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
    }
}
