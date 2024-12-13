using System;

namespace RoomsDesigner.Core.Domain.Entities
{
	public class Reward : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}
