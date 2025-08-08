using BookingSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Master> Masters { get; set; }
        public DbSet<Service> Services { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options)
        {
            
        }

        
    }
}
