using Microsoft.EntityFrameworkCore; // נדרש ל-AddDbContext ול-UseSqlServer
using Lesson8; // בהנחה ש-MyDbContext נמצא כאן
namespace Lesson8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // הוספת ה-DbContext ל-Dependency Injection Container
            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                // קורא את מחרוזת החיבור מתוך appsettings.json
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.
            builder.Services.AddControllers();

            // Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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