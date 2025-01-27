using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Implementations.Base;
using BookOfHabitsMicroservice.Application.Services.Implementations.Default_values;
using BookOfHabitsMicroservice.Application.Services.Implementations.FactoryMethodDomain;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Application.Services.Implementations
{
    public class HabitsApplicationService(
        IRepository<Habit, Guid> habitRepository,
        IRepository<Person, Guid> personRepository,
        IRoomRepository roomRepository,
        IRepository<Delay, Guid> delayRepository,
        IRepository<Repetition, Guid> repetitionRepository,
        IRepository<TimeResetInterval, Guid> timeResetIntervalRepository,
        IFactory<Habit> habitFactory,
        IMapper mapper) : BaseService, IHabitsApplicationService
    {
        public async Task<HabitModel?> AddHabitAsync(CreateHabitModel cardInfo, CancellationToken token = default)
        {
            Person owner = await personRepository.GetByIdAsync(x => x.Id.Equals(cardInfo.PersonId), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(cardInfo.PersonId, nameof(Person)));

            Room room = await roomRepository.GetByIdAsync(x => x.Id.Equals(cardInfo.RoomId), includes: $"_habits", cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(cardInfo.RoomId, nameof(Room)));

            var habit = habitFactory.FactoryMethod([cardInfo.Name, cardInfo.Description])
                ?? throw new BadRequestException(BadRequestEntityExistsMessage(cardInfo.RoomId, nameof(Habit)));
            habit.SetPerson(owner);
            habit.SetRoom(room);

            await roomRepository.UpdateAsync(entity: room, cancellationToken: token);
            await personRepository.UpdateAsync(entity: owner, cancellationToken: token);
            habit = await habitRepository.AddAsync(entity: habit, cancellationToken: token)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(habit.Id, nameof(Habit)));
            return mapper.Map<HabitModel>(habit);
        }

        public async Task DeleteHabit(Guid id, CancellationToken token = default)
        {
            var habit = await habitRepository.GetByIdAsync(filter: x => x.Id.Equals(id),
                                                           includes: $"{nameof(Habit.Delay)},{nameof(Habit.Repetition)},{nameof(Habit.TimeResetInterval)}",
                                                           cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Habit)));
            var delay = habit.Delay;
            var repetition = habit.Repetition;
            var timeResetInterval = habit.TimeResetInterval;
            if (await habitRepository.DeleteAsync(habit, token) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Habit)));
            await delayRepository.DeleteAsync(delay, token);
            await repetitionRepository.DeleteAsync(repetition, token);
            await timeResetIntervalRepository.DeleteAsync(timeResetInterval, token);
        }

        public async Task<IEnumerable<HabitModel>> GetAllRoomHabitsAsync(Guid roomId, CancellationToken token = default)
        {
            Room? room = await roomRepository.GetByIdAsync(filter: x => x.Id.Equals(roomId),
                                                           includes: $"_habits",
                                                           asNoTracking: true,
                                                           cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(roomId, nameof(Room)));

            return room.SuggestedHabits.Select(mapper.Map<HabitModel>);
        }

        public async Task<HabitModel?> GetHabitByIdAsync(Guid id, CancellationToken token = default)
        {
            Habit habit = await habitRepository.GetByIdAsync(x => x.Id.Equals(id),
                                                             includes: $"{nameof(Habit.Card)},{nameof(Habit.Owner)},{nameof(Habit.Delay)},{nameof(Habit.Repetition)},{nameof(Habit.TimeResetInterval)}",
                                                             asNoTracking: true,
                                                             cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Habit)));
            return mapper.Map<HabitModel>(habit);
        }

        public async Task UpdateHabit(UpdateHabitModel habitInfo, CancellationToken token = default)
        {
            Person owner = await personRepository.GetByIdAsync(x => x.Id.Equals(habitInfo.PersonId), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(habitInfo.PersonId, nameof(Person)));

            Habit habit = await habitRepository.GetByIdAsync(x => x.Id.Equals(habitInfo.Id), includes: nameof(Habit.Owner), cancellationToken: token)
                 ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(habitInfo.Id, nameof(Habit)));
            if (habit.Owner.Equals(owner) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(habitInfo.PersonId, nameof(Person)));

            if (habitInfo.Name is not null)
                habit.SetName(habitInfo.Name);
            if (habitInfo.Description is not null)
                habit.SetDescription(habitInfo.Description);
            habit.SetOptions(habitInfo.Options);
            await habitRepository.UpdateAsync(entity: habit, token);
        }
        public async Task UpdateDelayHabit(Guid habitId, UpdateDelayModel delayInfo, CancellationToken token = default)
        {
            Habit habit = await habitRepository.GetByIdAsync(x => x.Id.Equals(habitId), includes: nameof(Habit.Delay), cancellationToken: token)
                     ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(habitId, nameof(Habit)));
            Delay delay = await delayRepository.GetByIdAsync(x => x.Id.Equals(habit.Delay.Id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(habit.Delay.Id, nameof(Delay)));
            delay.SetIsAfterATime(delayInfo.IsAfterATime);
            delay.SetAfterTime(delayInfo.AfterTime);
            delay.SetIsEndless(delayInfo.IsEndless);
            delay.SetDurationTime(delayInfo.DurationTime);
            await delayRepository.UpdateAsync(entity: delay, token);
        }
        public async Task UpdateRepetitionHabit(Guid habitId, UpdateRepetitionModel repetitioInfo, CancellationToken token = default)
        {
            Habit habit = await habitRepository.GetByIdAsync(x => x.Id.Equals(habitId), includes: nameof(Habit.Repetition), cancellationToken: token)
                     ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(habitId, nameof(Habit)));
            Repetition repetition = await repetitionRepository.GetByIdAsync(x => x.Id.Equals(habit.Repetition.Id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(habit.Repetition.Id, nameof(Delay)));
            repetition.SetProperty(repetitioInfo.MaxCountPositive,
                                   repetitioInfo.MaxCountNegative,
                                   repetitioInfo.IsLimit,
                                   repetitioInfo.CountLimit);

            await repetitionRepository.UpdateAsync(entity: repetition, token);
        }

        public async Task UpdateTimeResetIntervalHabit(Guid habitId, UpdateTimeResetIntervalModel timeResetIntervalInfo, CancellationToken token = default)
        {
            Habit habit = await habitRepository.GetByIdAsync(x => x.Id.Equals(habitId), includes: nameof(Habit.TimeResetInterval), cancellationToken: token)
                     ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(habitId, nameof(Habit)));
            TimeResetInterval timeResetInterval = await timeResetIntervalRepository.GetByIdAsync(x => x.Id.Equals(habit.Repetition.Id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(habit.TimeResetInterval.Id, nameof(TimeResetInterval)));
            timeResetInterval.SetProperty(timeResetIntervalInfo.Options,
                                          timeResetIntervalInfo.TimeTheDay,
                                          timeResetIntervalInfo.WeekDays,
                                          timeResetIntervalInfo.NumberDayOfTheMonth);

            await timeResetIntervalRepository.UpdateAsync(entity: timeResetInterval, token);
        }
    }
}
