using DataAccess;
using DataAccessInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Factory
{
    public class RepositoryFactory
    {
        private readonly IServiceCollection services;

        public RepositoryFactory(IServiceCollection services)
        {
            this.services = services;
        }

        public void AddCustomServices()
        {
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddDbContext<DbContext, VidlyContext>(optionsBuilder => optionsBuilder.UseSqlServer("algo"));
        }
    }
}