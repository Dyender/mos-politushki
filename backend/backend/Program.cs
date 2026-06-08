using backend.Data;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load(Path.Combine(builder.Environment.ContentRootPath, ".env"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var postgresPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("DefaultConnection is not set.");
}

if (string.IsNullOrWhiteSpace(postgresPassword))
{
    throw new InvalidOperationException("POSTGRES_PASSWORD is not set.");
}

connectionString = connectionString.Replace("${POSTGRES_PASSWORD}", postgresPassword);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();