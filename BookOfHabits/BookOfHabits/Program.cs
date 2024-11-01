using BookOfHabits;
using BookOfHabits.Infrastructure.ExceptionHandling;
using BookOfHabits.Infrastructure.MigrationsManager;
using BookOfHabitsMicroservice.Application.Services.Implementations.Mapping;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;

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

builder.Services.AddAutoMapper(typeof(Program), typeof(CardMapping));

var app = builder.Build();

app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.UseErrorHandler();
app.MapControllers();
app.MigrateDatabase<ApplicationDbContext>();

app.Run();
