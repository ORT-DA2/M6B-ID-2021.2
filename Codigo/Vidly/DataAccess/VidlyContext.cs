using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class VidlyContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Product> Products { get; set; }

        public VidlyContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().Property(restaurant => restaurant.OwnerId).IsRequired(false);
            modelBuilder.Entity<User>().HasData(new User(), new User());
        }
    }
}