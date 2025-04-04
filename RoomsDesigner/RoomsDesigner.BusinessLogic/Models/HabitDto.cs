using RoomsDesigner.BusinessLogic.Models.Intermediate;
using RoomsDesigner.Core.Domain.Enums;
using System;
using System.Collections.Generic;

namespace RoomsDesigner.BusinessLogic.Models
{
	public class HabitDto : IEntityDto<Guid>
	{
		public Guid Id { get; init; }
		public required string Name { get; init; }
		public HabitCategory HabitCategory { get; init; }
		public List<RoomHabitDto> RoomHabits { get; set; }
	}
}
