using FluentValidation;
using Microsoft.OpenApi.Models;
using SingalR.BusinessLayer.Abstract;
using SingalR.BusinessLayer.Concrete;
using SingalR.BusinessLayer.Container;
using SingalR.BusinessLayer.ValidationRules.BookingValidations;
using SingalR.DataAccessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;
using SingalR.DataAccessLayer.EntityFramework;
using SingalRApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SingalRApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials()
                          .SetIsOriginAllowed(origin => true);
                });
            });

            builder.Services.AddSignalR();

            builder.Services.AddDbContext<SingalRContext>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.ContainerDependencies();

            builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();

            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = 
                    ReferenceHandler.IgnoreCycles);


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.MapHub<SignalRHub>("/signalrhub");

            app.Run();
        }
    }
}
