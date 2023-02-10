using CarpoolingWebAPI.Models;
using CarPoolingWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarpoolingWebAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<History> History { get; set; }
    }
}
