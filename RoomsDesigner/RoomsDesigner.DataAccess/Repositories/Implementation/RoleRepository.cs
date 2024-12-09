using RoomsDesigner.Core.Domain.Entities.Administration;
using RoomsDesigner.DataAccess.Abstrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnumRole = RoomsDesigner.Core.Domain.Enums.Role;

namespace RoomsDesigner.DataAccess.Repositories.Implementation
{
	public class RoleRepository : BaseRepostory<Role, int>, IRoleRepository
	{
		public RoleRepository(DatabaseContext context) : base(context)
		{ }

		public async Task<List<Role>> GetSelectedRoles(List<EnumRole> roles)
		{
			var rolesIds = roles.Select(x => (int)x);
			return await GetAllAsync(role => rolesIds.Contains(role.Id));
		}
	}
}
