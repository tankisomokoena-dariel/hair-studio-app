using backend.Application.Common.Interfaces.Repositories;
using backend.Infrastructure.Persistence.Interceptors;
using Domain.Interfaces;
using Infrastructure.Persistence.DatabaseContext;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddDbContext<HairStudioDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LocalConnection"),
                    builder => builder.MigrationsAssembly(typeof(HairStudioDbContext).Assembly.FullName));
            });

            
            services.AddScoped<IHairStudioDbContext>(provider => provider.GetRequiredService<HairStudioDbContext>());
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAvailabilitySlotRepository, AvailabilitySlotRepository>();

            return services;
        }
    }
}
