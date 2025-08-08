using BookingSystem.Data;
using BookingSystem.Interface;
using BookingSystem.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IMasterRepository, MasterRepository>();

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//ÏÎÊÀ ×ÒÎ ÏÐÈÍÈÌÀÅÌ ÇÀÏÐÎÑÛ Ñ ËÞÁÛÕ ÄÎÌÅÍÎÂ, ÏÎÒÎÌ ÈÑÏÐÀÂÈÒÜ
app.UseCors(builder => builder.AllowAnyOrigin());

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
