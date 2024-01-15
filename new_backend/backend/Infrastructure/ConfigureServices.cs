using backend.Application.Common.Interfaces.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.Interceptors;
using Persistence.Repositories;

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
            services.AddScoped<IBookingsRepository, BookingsRepository>();

            return services;
        }
    }
}
