using RoomsDesigner.Core.Abstractions.Repositories;
using RoomsDesigner.Core.Domain.Entities;
using RoomsDesigner.DataAccess.Abstrations;
using System;

namespace RoomsDesigner.DataAccess.Repositories
{
	public class DiaryRepository : BaseRepostory<Diary, Guid>, IRepository<Diary, Guid>
	{
		public DiaryRepository(DatabaseContext context) : base(context)
		{ }
	}
}
