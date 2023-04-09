using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace HotelBookingSystemAPI.Models
{
    public class Room
    {
        [Key]
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int Floor { get; set; }
        [Key]
        public int RoomNumber { get; set; }
        public string Description { get; set; }
        public double BaseRate { get; set; }
        public int? RoomStatusId { get; set; }
        public string? RoomTypeName { get; set; }
        public RoomType? RoomType { get; set; }
        public RoomStatus? RoomStatus { get; set; }
        public List<Payment>? Payments { get; set; }
        public List<Reservation>? Reservations { get; set; }
        public Room()
        {
            Payments = new List<Payment>();
            Reservations = new List<Reservation>();
        }

    }
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => new { r.HotelId, r.RoomNumber });

            // Other configuration options go here

            builder.HasOne(r => r.Hotel)
                   .WithMany(h => h.Rooms)
                   .HasForeignKey(r => r.HotelId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.RoomType)
                   .WithMany(rt => rt.Rooms)
                   .HasForeignKey(r => r.RoomTypeName)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.RoomStatus)
                   .WithMany(rs => rs.Rooms)
                   .HasForeignKey(r => r.RoomStatusId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
