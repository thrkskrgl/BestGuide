﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BestGuide.Modules.Infrastructure.Persistence
{
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

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {
            var configuration = GetDatabaseConfiguration();
            var connectionString = configuration.GetConnectionString("DBBestGuideConnection");

            services.AddDbContext<ModulesDbContext>(options =>
                options.UseNpgsql(connectionString, x => x.MigrationsHistoryTable(MigrationHistoryName, SchemaName)));

            return services;
        }
    }
}