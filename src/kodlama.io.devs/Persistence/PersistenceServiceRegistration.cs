using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("LanguageConnectionString")));
            services.AddScoped<ILanguageRepository, LanguageRepository>(); //eğer IBrandRepository istenirse ona BrandRepository ver

            return services;
        }
    }
}
