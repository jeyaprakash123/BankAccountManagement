using BankAccountManagement.Application.Cache;
using BankAccountManagement.Domain.Interfaces;
using BankAccountManagement.Infrastructure;
using BankAccountManagement.Infrastructure.Repository;
using BankAccountManagement.Application.Mapper;
using Microsoft.EntityFrameworkCore;
using BankAccountManagement.Application.Interface;
using BankAccountManagement.Application.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database configuration

builder.Services.AddDbContext<BankDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//AutoMapper configuration

builder.Services.AddAutoMapper(typeof(MappingProfile));

//Cache Configuration

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "BankAppCache";
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<RedisCacheService, RedisCacheService>();
builder.Services.AddScoped<IUserService,UserService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
