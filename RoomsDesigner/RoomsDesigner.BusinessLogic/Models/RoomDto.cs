using RoomsDesigner.BusinessLogic.Models.Intermediate;
using System;
using System.Collections.Generic;

namespace RoomsDesigner.BusinessLogic.Models
{
	public class RoomDto : IEntityDto<Guid>
	{
		public Guid Id { get; init; }
		public required string Name { get; init; }
		public Guid CreatedByUserId { get; init; }
		public List<RoomHabitDto> RoomHabits { get; set; }
		public List<UserRoomDto> UserRooms { get; set; }
	}
}
