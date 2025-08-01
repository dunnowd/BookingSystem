using BookingSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Master> Masters { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<MasterService> MasterServices { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Master>()
                .HasMany(e => e.Services)
                .WithMany(e => e.Masters)
                .UsingEntity<MasterService>();
        }
    }
}
