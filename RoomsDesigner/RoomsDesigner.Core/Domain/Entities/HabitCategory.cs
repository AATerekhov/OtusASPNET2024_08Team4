using System.Collections.Generic;

namespace RoomsDesigner.Core.Domain.Entities
{
	public class HabitCategory : IEntity<int>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<Habit> Habits { get; set; }
	}
}
