using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class VidlyContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        
        public VidlyContext(DbContextOptions options) : base(options) { }
    }
}