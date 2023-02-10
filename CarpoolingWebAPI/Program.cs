using CarpoolingWebAPI.Services;
using CarpoolingWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using CarpoolingWebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* In Memory */

//builder.Services.AddDbContext<UsersDbContext>(options => options.UseInMemoryDatabase("UsersDb"));

/* Database */

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=DESKTOP-AMMV1NQ\\SQLEXPRESS;Database=CarPoolingDB;Trusted_Connection=True;Trust Server Certificate=True;"));

builder.Services.AddScoped<IBookingServices,BookingServices>();
builder.Services.AddScoped<IOfferServices, OfferServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IHistoryServices, HistoryServices>();
builder.Services.AddScoped<ILoginServices, LoginServices>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
