using Microsoft.EntityFrameworkCore;
using simple_api.Models;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DevConnection");

builder.Services.AddDbContext<SimpleDBContext>(options =>
    options.UseSqlServer(connectionString, options =>
    {
        options.MigrationsAssembly(typeof(SimpleDBContext).Assembly.FullName.Split(',')[0]);

    }));

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(options =>
            options.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
