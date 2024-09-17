using Microsoft.EntityFrameworkCore;
using migrationDemo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DemoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
