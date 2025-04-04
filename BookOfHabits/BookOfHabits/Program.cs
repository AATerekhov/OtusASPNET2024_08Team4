using BookOfHabits;
using BookOfHabits.Infrastructure.ExceptionHandling;
using BookOfHabits.Infrastructure.HealthCheck;
using BookOfHabits.Infrastructure.MigrationsManager;
using BookOfHabits.Infrastructure.Settings;
using BookOfHabitsMicroservice.Application.Services.Implementations.Consumer;
using BookOfHabitsMicroservice.Application.Services.Implementations.Mapping;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDataContext(builder.Configuration);
builder.Services.AddRepository();
builder.Services.AddServices();

builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks().AddCheck<SimpleHealphCheck>("simpleHealph", tags: ["SimpleHealphCheck"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.Get<ApplicationSettings>().ApiGateWaySettings?.ValidApiKeys)),
              ValidateIssuer = true,
              ValidIssuer = "Gateway",
              ValidateAudience = true,
              ValidAudience = "Microservices",
              ValidateLifetime = true
          };
      });

builder.Services.AddAutoMapper(typeof(Program), typeof(CardMapping));

builder.Services.AddFluentValidationAutoValidation()
                .AddValidators();
builder.Services.AddMassTransit(configurator =>
{
    configurator.SetKebabCaseEndpointNameFormatter();
    configurator.AddConsumer<RoomDesignerRoomToBooksConsumer>();
    configurator.AddConsumer<ParticipantAddedInRoomConsumer>();
    configurator.UsingRabbitMq((context, configurator) =>
    {
        var rmqSettings = builder.Configuration.Get<ApplicationSettings>().RmqSettings;
        configurator.Host(rmqSettings.Host,
                    rmqSettings.VHost,
                    h =>
                    {
                        h.Username(rmqSettings.Login);
                        h.Password(rmqSettings.Password);
                    });
        configurator.ConfigureEndpoints(context);
    });
});

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

app.UseAuthentication();
app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.UseErrorHandler();
app.MapControllers();
app.MigrateDatabase<ApplicationDbContext>();

app.Run();
