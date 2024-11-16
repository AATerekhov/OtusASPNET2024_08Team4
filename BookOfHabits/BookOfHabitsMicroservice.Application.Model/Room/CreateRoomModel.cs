using BookOfHabitsMicroservice.Application.Models.Base;

namespace BookOfHabitsMicroservice.Application.Models.Room
{
    public class CreateRoomModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public Guid ManagerId { get; init; }
        public DateTime CreateDate { get; init; }
    }
}
