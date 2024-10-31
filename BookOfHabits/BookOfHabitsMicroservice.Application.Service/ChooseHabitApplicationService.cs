using BookOfHabitsMicroservice.Application.Models.Coins;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;

namespace BookOfHabitsMicroservice.Application.Services
{
    internal class ChooseHabitApplicationService (IRepository<Person,Guid> personRepository,
                                                IRepository<Habit, Guid> habitRepository,
                                                IRepository<Room, Guid> roomRepository,
                                                IRepository<Coins, Guid> coinsRepository): IChooseHabitApplicationService
    {
        public async Task<bool> ChooseHabitInTheRoomAsync(ChooseHabitModel chooseHabitModel)
        {
            return true;
        }
    }
}
