using BestGuide.Modules.Domain.Persistence;
using BestGuide.Modules.Domain.Services;
using BestGuide.Modules.Infrastructure.Persistence;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;
using System.Text.Json.Serialization;

namespace BestGuide.Modules
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDatabaseContext();

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

            builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();

            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IHotelContactService, HotelContactService>();

            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IHotelContactRepository, HotelContactRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
