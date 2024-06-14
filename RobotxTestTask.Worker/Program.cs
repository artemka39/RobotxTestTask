using ReobotxTestTask.Core.Services;
using RobotxTestTask.Worker;
using Refit;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<DataImportService>(); 

var host = builder.Build();
host.Run();
