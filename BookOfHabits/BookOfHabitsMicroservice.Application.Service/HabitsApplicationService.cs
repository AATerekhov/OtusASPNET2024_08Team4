using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Implementations.Base;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Application.Services.Implementations
{
    public class HabitsApplicationService(IRepository<Habit, Guid> habitRepository,
                                          IRepository<Person, Guid> personRepository,
                                          IRepository<Room, Guid> roomRepository,
                                          IRepository<Delay, Guid> delayRepository,
                                          IRepository<Repetition, Guid> repetitionRepository,
                                          IRepository<TimeResetInterval, Guid> timeResetIntervalRepository,
                                          IMapper mapper) : BaseService, IHabitsApplicationService
    {
        public async Task<HabitModel?> AddHabitAsync(CreateHabitModel cardInfo, CancellationToken token = default)
        {
            Person owner = await personRepository.GetByIdAsync(x => x.Id.Equals(cardInfo.PersonId), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(cardInfo.PersonId, nameof(Person)));

            Room room = await roomRepository.GetByIdAsync(x => x.Id.Equals(cardInfo.RoomId), includes: $"_habits", cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(cardInfo.RoomId, nameof(Room)));

            var delay = new Delay(isAfterATime: false,
                                  afterTime: 0,
                                  isEndless: true,
                                  durationTime: 3600);

            var repetition = new Repetition(maxCountPositive: 5,
                                            maxCountNegative: 5,
                                            isLimit: false,
                                            countLimit: 10);

            var timeResetInterval = new TimeResetInterval(options: ResetIntervalOptions.EveryDay,
                                                          timeTheDay: 43_200,
                                                          weekDays: WeekDays.None,
                                                          numberDayOfTheMonth: 10);

            var habit = new Habit(name: new HabitName(cardInfo.Name),
                                  description: cardInfo.Description,
                                  owner: owner,
                                  room: room,
                                  options: HabitOptions.None,
                                  delay: delay,
                                  repetition: repetition,
                                  timeResetInterval: timeResetInterval);

            habit = await habitRepository.AddAsync(habit, token)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(habit.Id, nameof(Habit)));
            await roomRepository.UpdateAsync(room, token);
            return mapper.Map<HabitModel>(habit);
        }

        public async Task DeleteHabit(Guid id, CancellationToken token = default)
        {
            var card = await habitRepository.GetByIdAsync(x => x.Id.Equals(id))
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Habit)));
            if (await habitRepository.DeleteAsync(card) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Habit)));
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
                                                                includes: $"{nameof(Habit.Card)};{nameof(Habit.Owner)};{nameof(Habit.Delay)};{nameof(Habit.Repetition)};{nameof(Habit.TimeResetInterval)}",
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
