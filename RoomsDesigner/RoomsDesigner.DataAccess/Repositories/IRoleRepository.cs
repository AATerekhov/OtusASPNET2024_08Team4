using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnumRole = RoomsDesigner.Core.Domain.Enums.Role;

namespace RoomsDesigner.DataAccess.Repositories
{
	public interface IRoleRepository : IRepository<Role, int>
	{
		Task<List<Role>> GetSelectedRoles(List<EnumRole> roles);
	}
}
