using FluentValidation;
using Microsoft.OpenApi.Models;
using SingalR.BusinessLayer.Abstract;
using SingalR.BusinessLayer.Concrete;
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

            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IAbuotDal, EfAboutDal>();

            builder.Services.AddScoped<IBookingService, BookingManager>();
            builder.Services.AddScoped<IBookingDal, EfBookingDal>();

            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IContactDal, EfContactDal>();

            builder.Services.AddScoped<IDiscountService, DiscountManager>();
            builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();

            builder.Services.AddScoped<IFeatureService, FeatureManager>();
            builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<IProductDal, EfProductDal>();

            builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
            builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
            builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

            builder.Services.AddScoped<IOrderService, OrderManager>();
            builder.Services.AddScoped<IOrderDal, EfOrderDal>();

            builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
            builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();

            builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
            builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();

            builder.Services.AddScoped<IMenuTableService, MenuTableManager>();
            builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();

            builder.Services.AddScoped<ISliderService, SliderManager>();
            builder.Services.AddScoped<ISliderDal, EfSliderDal>();

            builder.Services.AddScoped<IBasketService, BasketManager>();
            builder.Services.AddScoped<IBasketDal, EfBasketDal>();

            builder.Services.AddScoped<INotificationService, NotificationManager>();
            builder.Services.AddScoped<INotificationDal, EfNotificaitonDal>();

            builder.Services.AddScoped<IMessageService, MessageManager>();
            builder.Services.AddScoped<IMessageDal, EfMessageDal>();

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
