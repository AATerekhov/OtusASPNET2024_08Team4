using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using RoomsDesigner.BusinessLogic.Models;

namespace RoomsDesigner.BusinessLogic.Services
{
	public interface IDiaryService
	{
		Task<List<DiaryDto>> GetAllAsync();

		Task<DiaryDto> GetByIdAsync(Guid id);

		Task UpdateAsync(Guid id, string name);

		Task DeleteAsync(Guid id);
	}
}
