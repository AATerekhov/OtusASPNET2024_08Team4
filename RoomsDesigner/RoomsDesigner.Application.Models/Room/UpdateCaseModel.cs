namespace RoomsDesigner.Application.Models.Room
{
    public class UpdateCaseModel
    {
        public Guid Id { get; init; }
        public Guid OwnerId { get; init; }
        public required string Name { get; init; }
    }
}
