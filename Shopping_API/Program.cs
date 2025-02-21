using BusinessLayer;
using DataLayer.DbScript;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Implementations;
using ServiceLayer.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Register BLL & Service Layer
builder.Services.AddScoped<CategoryBLL>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<SubCategoryBLL>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<ProductBLL>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<CartBLL>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddControllers();
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
