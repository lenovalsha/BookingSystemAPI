﻿namespace HotelBookingSystemAPI.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Payment>? Payments { get; set; }
        public PaymentType()
        {
            Payments = new List<Payment>();
        }
    }
}
