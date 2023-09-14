using Microsoft.EntityFrameworkCore;
using BookingApi.Models;

namespace BookingApi.Repository
{
  public class BookingContext : DbContext
  {
    public BookingContext(DbContextOptions<BookingContext> options) : base(options)
    {
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         var connectionString = Environment.GetEnvironmentVariable("DOTNET_CONNECTION_STRING");
    //         optionsBuilder.UseSqlServer(connectionString);
    //     }
    // }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }
  }
}
