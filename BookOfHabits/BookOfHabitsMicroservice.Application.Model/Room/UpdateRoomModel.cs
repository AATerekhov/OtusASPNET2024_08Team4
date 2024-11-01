using BookOfHabitsMicroservice.Application.Models.Base;

namespace BookOfHabitsMicroservice.Application.Models.Room
{
    public class UpdateRoomModel:IModel<Guid>
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public bool IsActive { get; init; }
    }
}
