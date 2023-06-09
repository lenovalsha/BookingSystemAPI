﻿namespace HotelBookingSystemAPI.Models
{
    public class ReservationStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Reservation>? Reservations { get; set; }
        public ReservationStatus()
        {
            Reservations = new List<Reservation>(); 
        }
    }
}
