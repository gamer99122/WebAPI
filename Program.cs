using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<WebContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WebDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//Scaffold - DbContext "Server=192.168.20.134;Database=Web;User ID=Web;Password=123456;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models - NoOnConfiguring - UseDatabaseNames - NoPluralize - Force

