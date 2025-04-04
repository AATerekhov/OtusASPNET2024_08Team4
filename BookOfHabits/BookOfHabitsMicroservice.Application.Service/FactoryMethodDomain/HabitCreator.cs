using BookOfHabitsMicroservice.Application.Services.Implementations.Default_values;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.FactoryMethodDomain
{
    public class HabitCreator :DomainCreator<Habit>
    {
        public override Habit? FactoryMethod(string[] vars)
        {
            if (vars.Length == 1)
            {
                return new Habit(name: new HabitName(vars[0]),
                          description: string.Empty,
                          options: HabitOptions.Delayed,
                          delay: DefaultValues.GetDefaultDelay(),
                          repetition: DefaultValues.GetDefaultRepetition(),
                          timeResetInterval: DefaultValues.GetDefaultTimeResetInterval());
            }
            else if (vars.Length == 2)
            {
                return new Habit(name: new HabitName(vars[0]),
                          description: vars[1],
                          options: HabitOptions.Delayed,
                          delay: DefaultValues.GetDefaultDelay(),
                          repetition: DefaultValues.GetDefaultRepetition(),
                          timeResetInterval: DefaultValues.GetDefaultTimeResetInterval());
            }
            else return null;
        }
    }
}
