using RoomsDesigner.Core.Domain.Entities.Administration;
using System;

namespace RoomsDesigner.Core.Domain.Entities.IntermediateEntities
{
	public class UserRoom
	{
		public Guid UserId { get; set; }
		public User User { get; set; }
		public Guid RoomId { get; set; }
		public Room Room { get; set; }
		public Guid? DiaryId { get; set; }
		public Diary Diary { get; set; }
	}
}