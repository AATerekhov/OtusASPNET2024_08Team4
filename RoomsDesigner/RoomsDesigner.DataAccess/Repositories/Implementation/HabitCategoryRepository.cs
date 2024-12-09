using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities;
using RoomsDesigner.DataAccess.Abstrations;

namespace RoomsDesigner.DataAccess.Repositories.Implementation
{
	public class HabitCategoryRepository : BaseRepostory<HabitCategory, int>, IRepository<HabitCategory, int>
	{
		public HabitCategoryRepository(DatabaseContext context) : base(context)
		{ }
	}
}
