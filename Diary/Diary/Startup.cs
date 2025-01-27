using AutoMapper;
using Diary.Consumers;
using Diary.DataAccess;
using Diary.Mapping;
using Diary.MiddleWares;
using Diary.Settings;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using FluentValidation;
using Diary.Validators;

namespace Diary
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("diary_connection_db_string");

            services.AddDbContext<EfDbContext>(optionsBuilder
               => optionsBuilder
                   .UseNpgsql(connectionString));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
            });

            InstallAutomapper(services);

            services.AddServices(Configuration);
            services.AddControllers();
            services.AddHealthChecks().AddCheck<DiaryHealthCheck>("diaryHealth", tags: new string[] { "diaryHealthCheck" });
            services.AddServices(Configuration);
            services.AddControllers();
            services.AddFluentValidationAutoValidation();
            services.AddValidators();

            services.AddMassTransit(configurator =>
            {
                configurator.SetKebabCaseEndpointNameFormatter();
                configurator.AddConsumer<CreateDiaryLineFromMagazineConsumer>();
                configurator.AddConsumer<RoomDesignerStartingRoomConsumer>();

                configurator.UsingRabbitMq((context, cfg) =>
                {
                    var rmqSettings = Configuration.Get<ApplicationSettings>()!.RmqSettings;
                    cfg.Host(rmqSettings.Host,
                                rmqSettings.VHost,
                                h =>
                                {
                                    h.Username(rmqSettings.Login);
                                    h.Password(rmqSettings.Password);
                                });
                  cfg.ConfigureEndpoints(context);
                });

            });

            services.AddOpenApiDocument(options =>
            {
                options.Title = "Diary API doc";
                options.Version = "1.0";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseOpenApi();
            app.UseSwaggerUi(x =>
            {
                x.DocExpansion = "list";
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseHealthChecks("/diaryHealth", new HealthCheckOptions(){
                Predicate = healthCheck => healthCheck.Tags.Contains("diaryHealthCheck")
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IServiceCollection InstallAutomapper(IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<HabitDiaryOwnerMappingsProfile>();
                cfg.AddProfile<HabitDiaryMappingsProfile>();
                cfg.AddProfile<HabitDiaryLineMappingsProfile>();
                cfg.AddProfile<HabitMappingsProfile>();
                cfg.AddProfile<HabitStateMappingsProfile>();
            });

            configuration.AssertConfigurationIsValid();
            return configuration;
        }      

    }
}
