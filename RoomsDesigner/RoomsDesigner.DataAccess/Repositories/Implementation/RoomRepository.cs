using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities;
using RoomsDesigner.DataAccess.Abstrations;
using System;

namespace RoomsDesigner.DataAccess.Repositories.Implementation
{
	public class RoomRepository : BaseRepostory<Room, Guid>, IRepository<Room, Guid>
	{
		public RoomRepository(DatabaseContext context) : base(context)
		{ }
	}
}
