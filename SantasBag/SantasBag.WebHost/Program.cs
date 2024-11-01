using Microsoft.EntityFrameworkCore;
using SantasBag.BusinessLogic.Services;
using SantasBag.Core.Abstractions;
using SantasBag.DataAccess;
using SantasBag.DataAccess.Entities;
using SantasBag.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SantasBagDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(SantasBagDbContext)));
    });

builder.Services.AddScoped<IRewardsService, RewardsService>();
builder.Services.AddScoped<IRewardsRepository<RewardEntity>, RewardsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
