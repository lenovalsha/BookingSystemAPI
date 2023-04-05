using Microsoft.EntityFrameworkCore;
using HotelBookingSystemAPI.Models;

namespace HotelBookingSystemAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DataContext()
        {

        }
        protected override void  OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=localhost;database=HotelBookingSystem;user id=sa;password=P@ssword!;encrypt=false");
            options.EnableSensitiveDataLogging();
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<RoomStatus> RoomStatus { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Admin> Admins { get; set; }





    }
}
