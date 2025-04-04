using BookOfHabitsMicroservice.Application.Models.Person;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions
{
    public interface IPersonsApplicationService
    {
        Task<IEnumerable<PersonModel>> GetAllPersonsAsync(CancellationToken token = default);
        Task<PersonModel?> GetPersonByIdAsync(Guid id, CancellationToken token = default);
        Task<PersonModel?> AddPersonAsync(CreatePersonModel personInfo, CancellationToken token = default);
        Task UpdatePerson(UpdatePersonModel person, CancellationToken token = default);
        Task DeletePersont(Guid id, CancellationToken token = default);
    }
}
