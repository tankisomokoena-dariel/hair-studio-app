using Application.AvailabilitySlots.Services;
using backend.Application.Bookings.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<IAvailabilitySlotService, AvailabilitySlotService>();
            services.AddScoped<IBookingsService, BookingsService>();

            return services;
        }
    }
}
