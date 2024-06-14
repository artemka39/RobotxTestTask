using ReobotxTestTask.Core.Services;
using RobotxTestTask.Data;
using RobotxTestTask.Data.DataServices;
using Microsoft.EntityFrameworkCore;

namespace RobotxTestTask.Api
{
    public static class WebAppBuilderExtension
    {
        public static void ConfigureBuilder(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.ConfigureEntityServices();
            builder.Services.AddDbContextPool<TestTaskDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("DrinksVendingMachine")));
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
        }
        public static void ConfigureEntityServices(this IServiceCollection services)
        {
            services.AddScoped<CardService>();
            services.AddScoped<CardDataService>();
        }
    }
}
