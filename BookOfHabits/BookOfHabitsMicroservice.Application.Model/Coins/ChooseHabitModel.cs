using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Coins
{
    public class ChooseHabitModel
    {
        public Guid PersonId { get; init; }
        public Guid RoomId { get; init; }
        public Guid HabitId { get; init; }
        public Guid CoinsId { get; init; }
    }
}
