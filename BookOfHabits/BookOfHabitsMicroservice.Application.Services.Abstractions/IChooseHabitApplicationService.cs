using BookOfHabitsMicroservice.Application.Models.Coins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions
{
    public interface IChooseHabitApplicationService
    {
        Task<bool> ChooseHabitInTheRoomAsync(ChooseHabitModel chooseHabitModel);
    }
}
