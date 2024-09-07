using Medfar.Interview.DAL.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Serilog to log to a file
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // Set the minimum logging level (e.g., Information, Error)
    .WriteTo.File("logs/log.txt",
                  rollingInterval: RollingInterval.Day,   // Log files will roll every day
                  fileSizeLimitBytes: 10 * 1024 * 1024,   // Limit file size to 10MB (optional)
                  retainedFileCountLimit: 7,              // Keep logs for 7 days (optional)
                  outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}") // Optional template
    .CreateLogger();

// Use Serilog as the logging provider
builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddSingleton<UserRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
