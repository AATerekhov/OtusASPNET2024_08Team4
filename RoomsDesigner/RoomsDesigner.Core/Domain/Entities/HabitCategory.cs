namespace RoomsDesigner.Core.Domain.Entities
{
	public class HabitCategory : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}
