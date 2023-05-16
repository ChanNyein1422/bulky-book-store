using BulkyBookAPI.Services.Book;
using BulkyBookAPI.Services.Category;
using BulkyBookAPI.Services.Dashboard;
using BulkyBookAPI.Services.Order;
using BulkyBookAPI.Services.OrderDetail;
using BulkyBookAPI.Services.User;
using BulkyBookAPI.Services.WishList;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:7098/"
                            )
                          .AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                      });
});

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IValidate>(s => new ValidateBase(s.GetService<ApplicationDbContext>()));
builder.Services.AddScoped<IUser>(s => new UserBase( s.GetService<ApplicationDbContext>()));
builder.Services.AddScoped<IBook>(s => new BookBase(s.GetService<ApplicationDbContext>()));
builder.Services.AddScoped<ICategory>(s => new CategoryBase(s.GetService<ApplicationDbContext>()));
builder.Services.AddScoped<IOrder>(s => new OrderBase(s.GetService<ApplicationDbContext>()));
builder.Services.AddScoped<IOrderDetail>(s => new OrderDetailBase(s.GetService<ApplicationDbContext>()));
builder.Services.AddScoped<ICount>(s => new CountBase(s.GetService<ApplicationDbContext>()));
builder.Services.AddScoped<IWishList>(s => new WishListBase(s.GetService<ApplicationDbContext>()));



var app = builder.Build();

//app.UseCors(MyAllowSpecificOrigins);

//app.UseCors();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

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
