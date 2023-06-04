using Aplication.interfaces;
using Aplication.Services;
using Domain.Interfaces;
using Infrastructure.Persistance.Data;
using Infrastructure.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Aplication.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var origin = builder.Configuration.GetSection("Origins:DefaultOrigins").Get<string[]>();

builder.Services.AddDbContext<ApiDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("ToDoListWebApi")));

//Repository
builder.Services.AddScoped<ITaskRepository,TaskRepository>();
builder.Services.AddScoped<INoteRepository,NoteRepository>();


//Services
builder.Services.AddScoped<ITaskService,TaskServivce>();
builder.Services.AddScoped<INoteService,NoteService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.WithOrigins(origin)
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
