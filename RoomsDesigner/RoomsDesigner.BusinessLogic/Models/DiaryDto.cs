using System;

namespace RoomsDesigner.BusinessLogic.Models
{
	public class DiaryDto : IEntityDto<Guid>
	{
		public Guid Id { get; init; }
		public required string Name { get; init; }
	}
}
