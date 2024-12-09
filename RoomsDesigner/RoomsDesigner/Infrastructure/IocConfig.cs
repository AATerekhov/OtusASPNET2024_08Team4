using Microsoft.Extensions.DependencyInjection;
using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities;
using RoomsDesigner.Core.Domain.Entities.Administration;
using RoomsDesigner.DataAccess.Repositories;
using RoomsDesigner.DataAccess.Repositories.Implementation;
using System;

namespace RoomsDesigner.Api.Infrastructure
{
	public static class IocConfig
	{
		public static void AddRoomDesignerServices(this IServiceCollection services)
		{
			AddDataAccessLayerRepositories(services);
		}

		private static void AddDataAccessLayerRepositories(this IServiceCollection services)
		{
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IRepository<HabitCategory, int>, HabitCategoryRepository>();
			services.AddScoped<IRepository<Diary, Guid>, DiaryRepository>();
			services.AddScoped<IRepository<Habit, Guid>, HabitRepository>();
			services.AddScoped<IRepository<Room, Guid>, RoomRepository>();
			services.AddScoped<IRepository<User, Guid>, UserRepository>();
		}
	}
}
