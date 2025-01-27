using RoomsDesigner.Core.Domain.Entities.IntermediateEntities;
using System;
using System.Collections.Generic;

namespace RoomsDesigner.Core.Domain.Entities
{
	public class Room : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid CreatedByUserId { get; set; }

		public ICollection<UserRoom> UserRooms { get; set; }
		public ICollection<RoomHabit> RoomHabits { get; set; }
	}
}
