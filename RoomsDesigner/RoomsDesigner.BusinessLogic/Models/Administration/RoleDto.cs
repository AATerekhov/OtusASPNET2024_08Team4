namespace RoomsDesigner.BusinessLogic.Models.Administration
{
	public class RoleDto : IEntityDto<int>
	{
		public int Id { get; init; }
		public required string Name { get; init; }
		public required string Description { get; init; }
	}
}