﻿using AutoMapper;
using Diary.DataAccess;
using Diary.Mapping;
using Diary.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddDbContext<EfDbContext>(optionsBuilder
               => optionsBuilder
                   .UseNpgsql(Configuration.Get<ApplicationSettings>().ConnectionString));

            InstallAutomapper(services);
            services.AddServices(Configuration);
            services.AddControllers();

            services.AddServices(Configuration);
            services.AddControllers();

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
            });

            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}