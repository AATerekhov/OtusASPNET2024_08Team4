using BookOfHabits.Requests.Card;
using BookOfHabits.Requests.Habit;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using FluentValidation;

namespace BookOfHabits.Infrastructure.Validators
{
    public class CreateHabitValidator: BaseCommonValidator<CreateHabitRequest>
    {
    }
}
