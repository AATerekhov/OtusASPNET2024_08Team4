using RoomsDesigner.BusinessLogic.Models.Administration.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomsDesigner.BusinessLogic.Services
{
	public interface IUserService
	{
		Task<List<UserDto>> GetAllAsync();

		Task<UserDto> GetByIdAsync(Guid id);

		Task<UserDto> CreateAsync(CreateOrEditUserRequestDto model);

		Task UpdateAsync(Guid id, CreateOrEditUserRequestDto model);

		Task DeleteAsync(Guid id);
	}
}
