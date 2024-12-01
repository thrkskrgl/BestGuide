using BestGuide.Modules.Application.Consumers;
using BestGuide.Modules.Domain.Services;
using BestGuide.Modules.Infrastructure.Persistence;
using BestGuide.Modules.Options;
using MassTransit;
using MediatR;
using MediatR.Pipeline;
using NLog;
using NLog.Web;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json.Serialization;

namespace BestGuide.Modules
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromFile("Configurations/NLog.config").GetCurrentClassLogger();

            try
            {
                logger.Info("Application Starting...");

                var builder = WebApplication.CreateBuilder(args);

                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                builder.Host.UseNLog();

                builder.Services.RegisterDatabaseContext();

                builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
                    });

                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
                builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
                builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblies(Application.Meta.Assembly));

                builder.Services.AddAutoMapper(options =>
                {
                    options.AllowNullCollections = true;
                }, Assembly.GetExecutingAssembly());

                builder.Services.RegisterModulesRepositories();
                builder.Services.RegisterModulesServices();

                #region RabbitMQConfig
                var rabbitMQOptions = builder.Configuration.GetSection(RabbitMQOptions.CofigName).Get<RabbitMQOptions>();
                if (rabbitMQOptions is not null)
                {
                    builder.Services.AddMassTransit(config =>
                    {
                        config.AddConsumer<HotelReportCreateMessageConsumer>();

                        config.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(rabbitMQOptions.Host, h =>
                            {
                                h.Username(rabbitMQOptions.UserName);
                                h.Password(rabbitMQOptions.Password);
                            });

                            cfg.UseMessageRetry(r =>
                            {
                                r.Interval(5, TimeSpan.FromMinutes(1));
                            });

                            cfg.ConfigureEndpoints(context);
                        });
                    });
                }
                #endregion

                var app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of an exception");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}
