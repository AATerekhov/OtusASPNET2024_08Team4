using RoomsDesigner.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomsDesigner.BusinessLogic.Services
{
	public interface IHabitCategoryService
	{
		Task<List<HabitCategoryDto>> GetAllAsync();
	}
}
