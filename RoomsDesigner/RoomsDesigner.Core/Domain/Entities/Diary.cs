using System;

namespace RoomsDesigner.Core.Domain.Entities
{
	public class Diary : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}