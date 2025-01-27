namespace RoomsDesigner.BusinessLogic.Models
{
	public interface IEntityDto<TId>
	{
		TId Id { get; init; }
	}
}
