using BookOfHabits.Requests.Habit;
using FluentValidation;

namespace BookOfHabits.Infrastructure.Validators
{
    public class CreateHabitValidator: BaseCommonValidator<CreateHabitRequest>
    {
        public CreateHabitValidator()
        {
            RuleFor(x => x.RoomId).NotEqual(Guid.Empty);
            RuleFor(x => x.PersonId).NotEqual(Guid.Empty);
        }
    }
}
