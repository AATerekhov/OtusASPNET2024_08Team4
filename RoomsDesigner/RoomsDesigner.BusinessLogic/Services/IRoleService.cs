using RoomsDesigner.BusinessLogic.Models.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomsDesigner.BusinessLogic.Services
{
	public interface IRoleService
	{
		Task<List<RoleDto>> GetAllAsync();
	}
}
