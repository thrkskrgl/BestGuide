using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BestGuide.Report.Domain.Services
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterReportServices(this IServiceCollection services)
        {
            services.AddScoped<IHotelReportService, HotelReportService>();
            return services;
        }
    }
}
