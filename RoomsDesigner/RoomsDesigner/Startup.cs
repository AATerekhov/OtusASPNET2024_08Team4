using FluentValidation.AspNetCore;
using Humanizer.Configuration;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RoomsDesigner.Api.Infrastructure;
using RoomsDesigner.Api.Infrastructure.ExceptionHandling;
using RoomsDesigner.Api.Infrastructure.HealthChecks;
using RoomsDesigner.Api.Infrastructure.Settings;
using RoomsDesigner.Application.Services.Implementations.Mapping;
using RoomsDesigner.Infrastructure.EntityFramework;
using System.Text;
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
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.Get<ApplicationSettings>().ApiGateWaySettings?.ValidApiKeys)),
                        ValidateIssuer = true,
                        ValidIssuer = "Gateway",
                        ValidateAudience = true,
                        ValidAudience = "Microservices",
                        ValidateLifetime = true
                    };
                });

            services.AddAutoMapper(typeof(Program), typeof(CaseMapping));
            services.AddApplicationDataContext(Configuration);
			services.AddRoomDesignerServices();
			services.AddSwaggerServices();
            services.AddHealthChecks().AddCheck<SimpleHealphCheck>("simpleHealph", tags: ["SimpleHealphCheck"]);

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

      app.UseAuthentication();
      app.UseRouting();
      app.UseCors();
      app.UseAuthorization(); 
      app.UseHealthChecks("/healph", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
      {
          Predicate = healphCheck => healphCheck.Tags.Contains("SimpleHealphCheck")
      });

			app.UseErrorHandler();

      app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.MigrateDatabase<ApplicationDbContext>();
		}
	}
}
