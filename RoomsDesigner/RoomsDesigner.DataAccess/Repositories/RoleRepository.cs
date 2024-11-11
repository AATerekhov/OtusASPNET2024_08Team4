using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities.Administration;
using RoomsDesigner.DataAccess.Abstrations;

namespace RoomsDesigner.DataAccess.Repositories
{
	public class RoleRepository : BaseRepostory<Role, int>, IRepository<Role, int>
	{
		public RoleRepository(DatabaseContext context) : base(context)
		{ }
	}
}