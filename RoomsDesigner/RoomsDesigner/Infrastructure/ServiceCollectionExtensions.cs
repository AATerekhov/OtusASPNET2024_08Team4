using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoomsDesigner.DataAccess;

namespace RoomsDesigner.Api.Infrastructure
{
	public static class ServiceCollectionExtensions
	{
		public static void AddSwaggerServices(this IServiceCollection services)
		{
			services.AddOpenApiDocument(options =>
			{
				options.Title = "Room Designer API Doc";
				options.Version = "1.0";
			});
		}

		public static void UseSwaggerServices(this IApplicationBuilder app)
		{
			app.UseOpenApi();
			app.UseSwaggerUi(x =>
			{
				x.DocExpansion = "list";
			});
		}

		public static void MigrateDatabase<T>(this IApplicationBuilder application) where T : DatabaseContext
		{
			var scope = application.ApplicationServices.CreateScope();
			var dbContext = scope.ServiceProvider.GetService<T>();

			dbContext.Database.EnsureDeleted();
			dbContext.Database.Migrate();
			//Seed(scope.ServiceProvider);
		}
	}
}