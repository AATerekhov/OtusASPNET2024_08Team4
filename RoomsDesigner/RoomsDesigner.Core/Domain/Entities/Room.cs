namespace RoomsDesigner.Core.Domain.Entities
{
	public class Room : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid CreatedByUserId { get; set; }
	}
}
