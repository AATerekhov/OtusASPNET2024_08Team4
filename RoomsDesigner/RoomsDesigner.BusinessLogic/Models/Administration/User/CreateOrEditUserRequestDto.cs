using RoomsDesigner.Core.Domain.Enums;
using System.Collections.Generic;

namespace RoomsDesigner.BusinessLogic.Models.Administration.User
{
	public class CreateOrEditUserRequestDto
	{
		public required string Name { get; init; }
		public required string Email { get; init; }
		public List<Role> Roles { get; init; }
	}
}
