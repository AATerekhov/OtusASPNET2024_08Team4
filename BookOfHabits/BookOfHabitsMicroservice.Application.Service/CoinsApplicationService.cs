using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Coins;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Implementations.Base;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;

namespace BookOfHabitsMicroservice.Application.Services.Implementations
{
    public class CoinsApplicationService(ICoinsRepository coinsRepository,
                                         IRoomRepository roomRepository,
                                         IRepository<Person, Guid> personRepository,
                                         IRepository<Habit, Guid> habitRepository,
                                         IMapper mapper) : BaseService, ICoinsApplicationService
    {
        public async Task<bool> DeleteCoins(Guid id, CancellationToken token = default)
        {
            var coins = await coinsRepository.GetByIdAsync(filter: x => x.Id.Equals(id), includes:$"{nameof(Coins.Habit)}")
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Coins)));
            if (coins.Habit is not null)
            {
                Habit habit = coins.Habit;
                habit.UseInTheCoins(false);
                await habitRepository.UpdateAsync(entity: habit, cancellationToken: token);
            }               
            if (await coinsRepository.DeleteAsync(coins) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Coins)));
            return true;
        }

        public async Task<IEnumerable<CoinsModel>> GetAllRoomCoinsAsync(Guid roomId, CancellationToken token = default)
        {
            var bags = await coinsRepository.GetAllAsync(filter: x => x.Room.Id.Equals(roomId),
                                                         includes: $"{nameof(Coins.Room)},{nameof(Coins.Habit)}",
                                                         cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(roomId, nameof(Room)));

            return bags.Select(mapper.Map<CoinsModel>);
        }

        public async Task<CoinsModel> GetCoinsByIdAsync(Guid id, CancellationToken token = default)
        {
            Coins coins = await coinsRepository.GetDetailedCoinsByIdAsync(id, token: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Coins)));
            return mapper.Map<CoinsModel>(coins);
        }

        public async Task<bool> UpdateCoins(UpdateCoinsModel coinsInfo, CancellationToken token = default)
        {
            Person owner = await personRepository.GetByIdAsync(x => x.Id.Equals(coinsInfo.PersonId), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(coinsInfo.PersonId, nameof(Person)));

            Coins coins = await coinsRepository.GetDetailedCoinsByIdAsync(coinsInfo.Id, token)
                 ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(coinsInfo.Id, nameof(Coins)));
            if (coins.Room.Manager.Equals(owner) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(coinsInfo.PersonId, nameof(Person)));

            if (coinsInfo.Description is not null)
                coins.SetDescription(coinsInfo.Description);
            coins.SetProperty(options: coinsInfo.Options,
                              costOfWinning: coinsInfo.CostOfWinning,
                              forfeit: coinsInfo.Forfeit,
                              start: coinsInfo.Start,
                              falls: coinsInfo.Falls);
            await coinsRepository.UpdateAsync(entity: coins, token);
            return true;
        }
    }
}
