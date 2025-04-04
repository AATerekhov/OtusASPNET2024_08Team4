using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Person;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Implementations.Base;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Application.Services.Implementations
{
    public class PersonsApplicationService(IRepository<Person, Guid> personRepository,
                                            IMapper mapper) : BaseService, IPersonsApplicationService
    {
        public async Task<PersonModel?> AddPersonAsync(CreatePersonModel personInfo, CancellationToken token)
        {
            Person? person = await personRepository.GetByIdAsync(filter: x => x.Id.Equals(personInfo.Id), cancellationToken: token);
            if (person is not null)
                throw new BadRequestException(BadRequestEntityExistsMessage(personInfo.Id, nameof(Person)));

            person = new Person(personInfo.Id, new PersonName(personInfo.Name));
            person = await personRepository.AddAsync(person, token)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(personInfo.Id, nameof(Person)));
            return mapper.Map<PersonModel>(person);
        }

        public async Task DeletePersont(Guid id, CancellationToken token)
        {
            var person = await personRepository.GetByIdAsync(x => x.Id.Equals(id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Person)));
            if (await personRepository.DeleteAsync(person, token) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Person)));
        }

        public async Task<IEnumerable<PersonModel>> GetAllPersonsAsync(CancellationToken token)
        {
            return (await personRepository.GetAllAsync(asNoTracking: true, cancellationToken: token))
                .Select(mapper.Map<PersonModel>);
        }

        public async Task<PersonModel?> GetPersonByIdAsync(Guid id, CancellationToken token)
        {
            var person = await personRepository.GetByIdAsync(x => x.Id.Equals(id),
                                                                includes: "_habits",
                                                                asNoTracking: true,
                                                                cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Person)));
            return mapper.Map<PersonModel>(person);
        }

        public async Task UpdatePerson(UpdatePersonModel personInfo, CancellationToken token)
        {
            var person = await personRepository.GetByIdAsync(x => x.Id.Equals(personInfo.Id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(personInfo.Id, nameof(Person)));

            if (personInfo.Name is not null)
                person.SetName(personInfo.Name);
            await personRepository.UpdateAsync(person, token);
        }
    }
}
