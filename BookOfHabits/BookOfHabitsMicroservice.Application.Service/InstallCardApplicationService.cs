using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Base;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using Newtonsoft.Json.Linq;

namespace BookOfHabitsMicroservice.Application.Services
{
    public class InstallCardApplicationService(IRepository<Person, Guid> personRepository,
                                                IRepository<Habit, Guid> habitRepository,
                                                IRepository<Card, Guid> cardRepository) : BaseService, IInstallCardApplicationService
    {
        public async Task InstallCardAsync(InstallCardModel installCardModel, CancellationToken token = default)
        {
            Person owner = await personRepository.GetByIdAsync(x => x.Id.Equals(installCardModel.PersonId), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(installCardModel.PersonId, nameof(Person)));

            Habit habit = await habitRepository.GetByIdAsync(x => x.Id.Equals(installCardModel.HabitId), includes: $"{nameof(Habit.Owner)};{nameof(Habit.Card)}", cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(installCardModel.HabitId, nameof(Habit)));

            if (habit.Owner.Equals(owner) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(installCardModel.PersonId, nameof(Person)));
            if (habit.Card is not null)
                throw new BadRequestException(FormatBadRequestErrorMessage(installCardModel.HabitId, nameof(Habit)));

            Card card = await cardRepository.GetByIdAsync(x => x.Id.Equals(installCardModel.CardId), cancellationToken: token)
                 ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(installCardModel.HabitId, nameof(Habit)));
            habit.GetCard(card);

            await habitRepository.UpdateAsync(habit, token);
        }
    }
}
