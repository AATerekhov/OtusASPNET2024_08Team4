using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;

namespace BookOfHabitsMicroservice.Application.Services
{
    public class InstallCardApplicationService(IRepository<Person,Guid> personRepository,
                                                IRepository<Habit, Guid> habitRepository,
                                                IRepository<Card, Guid> templateCardRepository) : IInstallCardApplicationService
    {
        public async Task<bool> InstallCardAsync(InstallCardModel installCardModel)
        {
            return true;
        }
    }
}
