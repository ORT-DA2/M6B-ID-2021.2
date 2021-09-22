using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.Design
{
    public class DesignVidlyContext : IDesignTimeDbContextFactory<VidlyContext>
    {
        public VidlyContext CreateDbContext(string[] args)
        {
            DotNetEnv.Env.Load("./Environment/.env");
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);

            var vidlyContext = new VidlyContext(optionsBuilder.Options);

            return vidlyContext;
        }
    }
}