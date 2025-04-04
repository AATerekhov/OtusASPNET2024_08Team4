using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SantasBag.BusinessLogic.Services;
using SantasBag.Core.Abstractions;
using SantasBag.DataAccess;
using SantasBag.DataAccess.Entities;
using SantasBag.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddCors(options => options.AddPolicy("AllowAllFront", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = Environment.GetEnvironmentVariable("SANTASBAG_DBCONTEXT_CONNECTION_STRING");
builder.Services.AddDbContext<SantasBagDbContext>(
    options =>
    {
        options.UseNpgsql(connectionString);
    });

builder.Services.AddScoped<IRewardsService, RewardsService>();
builder.Services.AddScoped<IRewardsRepository<RewardEntity>, RewardsRepository>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SantasBagDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())   //временно для контейнера
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); //поддержка статических файлов
app.UseAuthorization();

app.UseCors("AllowAllFront");

app.MapControllers();

app.Run();
