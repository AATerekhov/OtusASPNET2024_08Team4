using System;

namespace RoomsDesigner.BusinessLogic.Models.Intermediate
{
	public class RoomHabitDto
	{
		public Guid RoomId { get; init; }
		public RoomDto Room { get; init; }
		public Guid HabitId { get; set; }
		public HabitDto Habit { get; set; }
		public Guid? SuggestedByUserId { get; set; }
		public bool? IsApproved { get; set; }
	}
}
