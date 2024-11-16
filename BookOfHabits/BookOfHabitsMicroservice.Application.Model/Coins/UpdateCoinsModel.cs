using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabitsMicroservice.Application.Models.Coins
{
    public class UpdateCoinsModel: IModel<Guid>
    {
        public Guid Id { get; init; }
        public Guid PersonId { get; init; }
        public string? Description { get; init; }
        public CoinsOptions Options { get; private set; }
        public int CostOfWinning { get; private set; }
        public int Forfeit { get; private set; }
        public int Start { get; private set; }
        public int Falls { get; private set; }
    
    }
}
