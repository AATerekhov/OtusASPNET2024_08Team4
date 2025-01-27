using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoomsDesigner.Api.Infrastructure;
using RoomsDesigner.Api.Infrastructure.ExceptionHandling;
using RoomsDesigner.Api.Infrastructure.Settings;
using RoomsDesigner.Application.Services.Implementations.Mapping;
using RoomsDesigner.Infrastructure.EntityFramework;
using System.Text.Json.Serialization;

namespace RoomsDesigner.Api
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
			services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
			});

            services.AddAutoMapper(typeof(Program), typeof(CaseMapping));
            services.AddApplicationDataContext(Configuration);
			services.AddRoomDesignerServices();
			services.AddSwaggerServices();

            services.AddFluentValidationAutoValidation()
                            .AddValidators();

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
        }

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwaggerServices();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseErrorHandler();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.MigrateDatabase<ApplicationDbContext>();
		}
	}
}
