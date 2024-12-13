using RoomsDesigner.Core.Domain.Entities.IntermediateEntities;
using System;
using System.Collections.Generic;

namespace RoomsDesigner.Core.Domain.Entities.Administration
{
	public class User : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public ICollection<Role> Roles { get; set; }
		public ICollection<UserRoom> UserRooms { get; set; }
	}
}