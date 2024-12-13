using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities;
using RoomsDesigner.DataAccess.Abstrations;
using System;

namespace RoomsDesigner.DataAccess.Repositories
{
	public class HabitRepository : BaseRepostory<Habit, Guid>, IRepository<Habit, Guid>
	{
		public HabitRepository(DatabaseContext context) : base(context)
		{ }
	}
}
