using Broadcaster;
using Broadcaster.Application.Services.Implementations.Mapping;
using Broadcaster.Infrastructure.HealthCheck;
using BroadcasterMicroservice.Infrastructure.MongoDbContext.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks().AddCheck<SimpleHealphCheck>("simpleHealph", tags: ["SimpleHealphCheck"]);

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddMongoContext();
builder.Services.AddServices();
builder.Services.AddRepository();
builder.Services.AddAutoMapper(typeof(Program), typeof(HabitNotificationMapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/healph", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
{
    Predicate = healphCheck => healphCheck.Tags.Contains("SimpleHealphCheck")
});

app.UseAuthorization();

app.MapControllers();

app.Run();
