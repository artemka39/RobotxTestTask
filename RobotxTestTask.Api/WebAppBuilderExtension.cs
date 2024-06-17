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
            builder.Services.RegisterDataServices(connectionString);
            builder.Services.AddScoped<CardService>();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
        }
    }
}
