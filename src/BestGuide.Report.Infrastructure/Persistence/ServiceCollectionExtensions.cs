using BestGuide.Report.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BestGuide.Report.Infrastructure.Persistence
{
    public static class ServiceCollectionExtensions
    {
        private const string SchemaName = "report";
        private const string MigrationHistoryName = "__EFMigrationsHistory";

        private static IConfiguration GetDatabaseConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("database.json", optional: false, reloadOnChange: true);

            return configurationBuilder.Build();
        }

        public static IServiceCollection RegisterDatabaseContext(this IServiceCollection services)
        {
            var configuration = GetDatabaseConfiguration();
            var connectionString = configuration.GetConnectionString("DBBestGuideConnection");

            services.AddDbContext<ReportDbContext>(options =>
                options.UseNpgsql(connectionString, x => x.MigrationsHistoryTable(MigrationHistoryName, SchemaName)));

            return services;
        }

        public static IServiceCollection RegisterReportRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IHotelReportRepository, HotelReportRepository>();
            return services;
        }
    }
}
