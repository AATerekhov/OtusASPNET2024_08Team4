using RoomsDesigner.BusinessLogic.Models.Administration;
using RoomsDesigner.BusinessLogic.Models.Administration.User;
using System;

namespace RoomsDesigner.BusinessLogic.Models.Intermediate
{
	public class UserRoomDto
	{
		public Guid UserId { get; set; }
		public UserDto User { get; set; }
		public Guid RoomId { get; set; }
		public RoomDto Room { get; set; }
		public Guid? DiaryId { get; set; }
		public DiaryDto Diary { get; set; }
	}
}
