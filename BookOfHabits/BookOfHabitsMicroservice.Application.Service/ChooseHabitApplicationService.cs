using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Coins;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Implementations.Base;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;

namespace BookOfHabitsMicroservice.Application.Services.Implementations
{
    public class ChooseHabitApplicationService(IRepository<Person, Guid> personRepository,
                                                IRepository<Habit, Guid> habitRepository,
                                                IRoomRepository roomRepository,
                                                ICoinsRepository coinsRepository,
                                                IMapper mapper) : BaseService, IChooseHabitApplicationService
    {
        public async Task<CoinsModel> ChooseHabitInTheRoomAsync(ChooseHabitModel chooseHabitModel, CancellationToken token = default)
        {
            Person owner = await personRepository.GetByIdAsync(filter: x => x.Id.Equals(chooseHabitModel.PersonId),
                                                               cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(chooseHabitModel.PersonId, nameof(Person)));

            Room room = await roomRepository.GetByIdAsync(filter: x => x.Id.Equals(chooseHabitModel.RoomId),
                                                          includes: $"{nameof(Room.Manager)},_habits,_bags",
                                                          cancellationToken: token)
                 ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(chooseHabitModel.RoomId, nameof(Room)));
            if (room.Manager.Equals(owner) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(chooseHabitModel.PersonId, nameof(Person)));

            Habit habit = await habitRepository.GetByIdAsync(filter: x => x.Id.Equals(chooseHabitModel.HabitId),
                                                             cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(chooseHabitModel.HabitId, nameof(Habit)));

            var coins = new Coins(room: room,
                                  habit: habit,
                                  description: chooseHabitModel.Description,
                                  options: CoinsOptions.None);
            room.GetCoins(coins);
            await habitRepository.UpdateAsync(entity: habit, cancellationToken: token);
            await roomRepository.UpdateAsync(entity: room, cancellationToken: token);
            coins = await coinsRepository.AddAsync(entity: coins, cancellationToken: token);
            return mapper.Map<CoinsModel>(coins);
        }
    }
}
