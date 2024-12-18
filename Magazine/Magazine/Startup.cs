using AutoMapper;
using Magazine.DataAccess;
using MagazineHost.Mapping;
using MagazineHost.Settings;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MagazineHost
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
            services.AddDbContext<EfDbContext>(optionsBuilder
               => optionsBuilder
                   .UseNpgsql(Configuration.Get<ApplicationSettings>().ConnectionString));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
            });

            InstallAutomapper(services);
            services.AddServices(Configuration);
            services.AddControllers();

            services.AddServices(Configuration);
            services.AddControllers();

            services.AddMassTransit(configurator =>
            {
                configurator.SetKebabCaseEndpointNameFormatter();
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
                options.Title = "Magazine API doc";
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
                cfg.AddProfile<RewardMagazineLineMappingProfile>();
                cfg.AddProfile<RewardMagazineMappingProfile>();
                cfg.AddProfile<RewardMagazineOwnerMappingProfile>();
            });

            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
