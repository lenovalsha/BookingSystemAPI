using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace HotelBookingSystemAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Postal { get; set; }
        public string? Phone{ get; set; }
        public string? Email { get; set; }
        public string? GuestEmail { get; set; }
        public Guest? Guest { get; set; }
        public int RoomNumber { get; set; }
        public Room? Room { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public double Rate { get; set; }
        public int Children { get; set; } = 2;
        public int Adults { get; set; } = 2;
        public int? ReservationStatusId { get; set; }
        public ReservationStatus? ReservationStatus { get; set; }

    }
}
