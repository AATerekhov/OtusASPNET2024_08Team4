namespace RoomsDesigner.Core.Domain
{
	public interface IEntity<TId>
	{
		TId Id { get; set; }
	}
}
