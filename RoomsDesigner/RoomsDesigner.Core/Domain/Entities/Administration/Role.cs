using System.Collections.Generic;

namespace RoomsDesigner.Core.Domain.Entities.Administration
{
	public class Role : IEntity<int>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<User> Users { get; set; }
	}
}
