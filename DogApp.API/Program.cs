using DogApp.Data;
using DogApp.Repository;
using DogApp.Repository.UserRepo;
using DogApp.Services;
using DogApp.Services.Interfaces;
using DogApp.Shared.EntityUserModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DogApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services, builder.Configuration);
            var app = builder.Build();
            Configure(app, builder.Environment);
            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Configure CORS policy.
            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins",
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:7243").AllowAnyHeader().AllowAnyMethod();
                    });
            });

            // Register repositories.
            services.AddScoped<ITrackRepo, TrackRepo>();
            services.AddScoped<IItemRepo, ItemRepo>();
            services.AddScoped<IUserRepository, UserRepo>();

            // Register services.
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IUserService, UserService>();

            // Configure DbContext.
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<DataContextApplicationUser>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("UserConnection"));
            });

            // Identity configuration
            services.AddIdentity<User, IdentityRole>(options =>
            {
                // Configure identity options if needed
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<DataContextApplicationUser>() // Use the ApplicationUser connection for Identity
            .AddDefaultTokenProviders(); // Add this line to enable default token providers

            services.AddControllersWithViews();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("_myAllowSpecificOrigins");
            app.UseRouting();
            app.UseAuthentication(); // Add authentication middleware
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
