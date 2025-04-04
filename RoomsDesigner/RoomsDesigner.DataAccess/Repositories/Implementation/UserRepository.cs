using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities.Administration;
using RoomsDesigner.DataAccess.Abstrations;
using System;

namespace RoomsDesigner.DataAccess.Repositories.Implementation
{
	public class UserRepository : BaseRepostory<User, Guid>, IRepository<User, Guid>
	{
		public UserRepository(DatabaseContext context) : base(context)
		{ }
	}
}
