using RoomsDesigner.BusinessLogic.Models;
using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomsDesigner.BusinessLogic.Services.Implementation
{
	public class HabitCategoryService : IHabitCategoryService
	{
		private readonly IRepository<HabitCategory, int> _habitCategoryRepository;

		public HabitCategoryService(IRepository<HabitCategory, int> habitCategoryRepository)
		{
			_habitCategoryRepository = habitCategoryRepository;
		}

		public async Task<List<HabitCategoryDto>> GetAllAsync()
			=> (await _habitCategoryRepository.GetAllAsync(asNoTracking: true)).Select(x => new HabitCategoryDto
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description
			}).ToList();

	}
}
