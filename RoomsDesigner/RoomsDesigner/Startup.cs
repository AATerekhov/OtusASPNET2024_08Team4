using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoomsDesigner.Api.Infrastructure;
using RoomsDesigner.Api.Infrastructure.ExceptionHandling;
using RoomsDesigner.DataAccess;
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

			services.AddApplicationDataContext(Configuration);
			services.AddRoomDesignerServices();
			services.AddSwaggerServices();
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

			app.MigrateDatabase<DatabaseContext>();
		}
	}
}
