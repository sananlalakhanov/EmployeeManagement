using EmployeeManagement.Persistence;
using EmployeeManagement.WebApi.Infrastructure;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<RequestMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
