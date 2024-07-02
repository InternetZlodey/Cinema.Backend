using Cinema.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Persinstence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CinemaDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<ICinemaDbContext>(provider =>
                provider.GetService<CinemaDbContext>());
            
            return services;
        }
    }
}
