using BookOfHabitsMicroservice.Application.Models.Coins;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions
{
    public interface IChooseHabitApplicationService
    {
        Task<CoinsModel> ChooseHabitInTheRoomAsync(ChooseHabitModel chooseHabitModel, CancellationToken token = default);
    }
}
