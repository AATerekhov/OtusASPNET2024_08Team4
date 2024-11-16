using System;

namespace RoomsDesigner.Core.Domain.Entities.IntermediateEntities
{
	public class RoomHabit
	{
		public Guid RoomId { get; set; }
		public Room Room { get; set; }
		public Guid HabitId { get; set; }
		public Habit Habit { get; set; }
		public Guid? SuggestedByUserId { get; set; }
		public bool? IsApproved { get; set; }
	}
}
