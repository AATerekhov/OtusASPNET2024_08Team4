namespace RoomsDesigner.Application.Models.Room
{
    public class CreateCaseModel
    {
        public Guid OwnerId { get; init; }
        public required string Name { get; init; }
    }
}
