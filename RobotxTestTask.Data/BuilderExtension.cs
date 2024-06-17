using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RobotxTestTask.Data.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotxTestTask.Data
{
    public static class BuilderExtension
    {
        public static void RegisterDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<TestTaskDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<CardDataService>();
        }
    }
}
