using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("Promomash"));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();


            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(configurePolicy: policy =>
            {
                policy.WithOrigins("https://localhost:4200");
                policy.WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS");
                policy.AllowAnyHeader();
                policy.SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dataContext.Database.EnsureCreated();
            }

            app.Run();
        }
    }
}
