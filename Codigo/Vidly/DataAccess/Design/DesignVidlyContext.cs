using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.Design
{
    public class DesignVidlyContext : IDesignTimeDbContextFactory<VidlyContext>
    {
        public VidlyContext CreateDbContext(string[] args)
        {
            DotNetEnv.Env.Load("");
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer("Server=DESKTOP-7PG3478;Database=VidlyDB;Trusted_Connection=True;MultipleActiveResultSets=True;");

            var vidlyContext = new VidlyContext(optionsBuilder.Options);

            return vidlyContext;
        }
    }
}