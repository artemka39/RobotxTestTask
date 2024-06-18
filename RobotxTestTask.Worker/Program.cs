using ReobotxTestTask.Core.Services;
using RobotxTestTask.Worker;
using RobotxTestTask.Data;
using RobotxTestTask.Core.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.RegisterDataServices(connectionString);
builder.Services.AddSingleton<ExcelDataImportService>();
builder.Services.AddScoped<CardService>();

var host = builder.Build();
host.Run();
