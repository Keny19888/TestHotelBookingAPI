using Microsoft.EntityFrameworkCore;
using TestHotelBookingAPI.Models;

namespace TestHotelBookingAPI.Data
{
  public class ApiContext : DbContext
  {

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Room> Rooms { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Booking>()
        .HasOne(b => b.Client)
        .WithMany(c => c.Bookings)
        .HasForeignKey(b => b.ClientId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Booking>()
        .HasOne(b => b.Room)
        .WithMany(r => r.Bookings)
        .HasForeignKey(b => b.RoomId)
        .OnDelete(DeleteBehavior.Cascade);
    }

  }
}