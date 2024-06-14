using RobotxTestTask.Api;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureBuilder();
var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
await app.RunAsync();