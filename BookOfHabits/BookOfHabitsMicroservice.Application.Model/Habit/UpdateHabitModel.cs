using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class UpdateHabitModel : ICreateModel
    {
        public Guid Id { get; init; }
        public Guid PersonId { get; set; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public HabitOptions Options { get; init; }
    }
}
