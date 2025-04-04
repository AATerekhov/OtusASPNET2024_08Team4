using RoomsDesigner.BusinessLogic.Models.Administration.User;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using RoomsDesigner.BusinessLogic.Models;

namespace RoomsDesigner.BusinessLogic.Services
{
	public interface IHabitService
	{
		Task<List<HabitDto>> GetAllAsync();

		Task<HabitDto> GetByIdAsync(Guid id);

		Task<HabitDto> CreateAsync(CreateOrEditUserRequestDto model);

		Task UpdateAsync(Guid id, CreateOrEditUserRequestDto model);

		Task DeleteAsync(Guid id);
	}
}
