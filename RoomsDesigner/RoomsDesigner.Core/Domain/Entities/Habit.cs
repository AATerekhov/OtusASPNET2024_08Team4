using RoomsDesigner.Core.Domain.Entities.IntermediateEntities;
using System;
using System.Collections.Generic;

namespace RoomsDesigner.Core.Domain.Entities
{
	public class Habit : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int HabitCategoryId { get; set; }
		public HabitCategory HabitCategory { get; set; }
		public ICollection<RoomHabit> RoomHabits { get; set; }
	}
}
