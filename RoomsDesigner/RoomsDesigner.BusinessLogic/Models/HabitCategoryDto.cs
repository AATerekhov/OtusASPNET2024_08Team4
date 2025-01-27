namespace RoomsDesigner.BusinessLogic.Models
{
	public class HabitCategoryDto : IEntityDto<int>
	{
		public int Id { get; init; }
		public required string Name { get; init; }
		public required string Description { get; set; }
	}
}
