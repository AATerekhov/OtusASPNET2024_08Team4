using System;
using System.Collections.Generic;

namespace RoomsDesigner.BusinessLogic.Models.Administration.User
{
	public class UserDto : IEntityDto<Guid>
	{
		public Guid Id { get; init; }
		public required string Name { get; init; }
		public required string Email { get; init; }
		public List<RoleDto> Roles { get; set; }
	}
}
