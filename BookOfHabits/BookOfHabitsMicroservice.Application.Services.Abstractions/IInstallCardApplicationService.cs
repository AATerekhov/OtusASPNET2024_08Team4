using BookOfHabitsMicroservice.Application.Models.Habit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions
{
    public interface IInstallCardApplicationService
    {
        Task InstallCardAsync(InstallCardModel installCardModel, CancellationToken token = default);
    }
}
