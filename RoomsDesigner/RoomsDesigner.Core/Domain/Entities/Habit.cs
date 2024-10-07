namespace RoomsDesigner.Core.Domain.Entities
{
	public class Habit : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid HabitCategoryId { get; set; }
	}
}
