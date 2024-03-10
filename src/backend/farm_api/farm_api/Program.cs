using DAL.Context;
using farm_api.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.ConfigureServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigurePieline();
app.UseDataSeeder();

app.Run();
