using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoomsDesigner.Api.Infrastructure.Validators;
using RoomsDesigner.Api.Requests.Case;
using RoomsDesigner.Application.Service.Abstractions;
using RoomsDesigner.Application.Services.Implementations;
using RoomsDesigner.Domain.Repository.Abstractions;
using RoomsDesigner.Infrastructure.EntityFramework;
using RoomsDesigner.Infrastructure.Repository.Implementations;

namespace RoomsDesigner.Api.Infrastructure
{
    public static class IocConfig
	{
        public static IServiceCollection AddApplicationDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connections = configuration.GetConnectionString("Postgres");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connections,
                optionsBuilder => optionsBuilder.MigrationsAssembly("RoomsDesigner.Infrastructure.EntityFramework"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            return services;
        }
        public static void AddRoomDesignerServices(this IServiceCollection services)
		{
			AddDataAccessLayerRepositories(services);
            AddApplicationsService(services);
        }
		private static void AddApplicationsService(this IServiceCollection services) 
		{
            services.AddScoped<ICaseService, СaseService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<ILaunchService, LaunchService>();
        }
		private static void AddDataAccessLayerRepositories(this IServiceCollection services)
		{
			services.AddScoped<ICaseRepository, CaseRepository>();
			services.AddScoped<IParticipantRepository, ParticipantRepository>();
		}
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateCaseValidator<CreateCaseRequest>>();
            services.AddValidatorsFromAssemblyContaining<UpdateCaseValidator>();
            services.AddValidatorsFromAssemblyContaining<LaunchValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateParticipantValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateParticipantValidator>();
            return services;
        }
    }
}
