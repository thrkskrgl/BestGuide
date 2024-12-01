using BestGuide.Modules.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BestGuide.Modules.Infrastructure.Persistence
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        private const string SchemaName = "modules";
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

            services.AddDbContext<ModulesDbContext>(options =>
                options.UseNpgsql(connectionString, x => x.MigrationsHistoryTable(MigrationHistoryName, SchemaName)));

            return services;
        }

        public static IServiceCollection RegisterModulesRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelContactRepository, HotelContactRepository>();
            return services;
        }
    }
}
