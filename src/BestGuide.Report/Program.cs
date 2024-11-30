using BestGuide.Report.Application.Consumers;
using BestGuide.Report.Domain.Services;
using BestGuide.Report.Infrastructure.Persistence;
using BestGuide.Report.Options;
using MassTransit;
using MediatR.Pipeline;
using MediatR;
using System.Reflection;
using System.Text.Json.Serialization;

namespace BestGuide.Report
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.RegisterDatabaseContext();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
                });

            builder.Services.AddControllers();
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

            builder.Services.RegisterReportRepositories();
            builder.Services.RegisterReportServices();

            var rabbitMqOptions = builder.Configuration.GetSection(RabbitMQOptions.CofigName).Get<RabbitMQOptions>();
            builder.Services.AddMassTransit(config =>
            {
                config.AddConsumer<HotelReportUpdateMessageConsumer>();

                config.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rabbitMqOptions.Host, h =>
                    {
                        h.Username(rabbitMqOptions.UserName);
                        h.Password(rabbitMqOptions.Password);
                    });

                    cfg.UseMessageRetry(r =>
                    {
                        r.Interval(5, TimeSpan.FromMinutes(1));
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

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
    }
}
