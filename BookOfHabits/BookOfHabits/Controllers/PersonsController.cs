using BookOfHabitsMicroservice.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BookOfHabits.Responses.Person;
using BookOfHabits.Requests.Person;
using BookOfHabitsMicroservice.Application.Models.Person;

namespace BookOfHabits.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonsController (IPersonsApplicationService personsApplicationService, 
                                    IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<PersonShortResponse>> GetAllPersons() 
        {
            IEnumerable<PersonModel> persons = await personsApplicationService.GetAllPersonsAsync(HttpContext.RequestAborted);
            return persons.Select(mapper.Map<PersonShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<PersonDetailedResponse> GetPersonById(Guid id)
        {
            var person = await personsApplicationService.GetPersonByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<PersonDetailedResponse>(person);
        }

        [HttpPost]
        public async Task<PersonShortResponse> CreatePerson(CreatePersonRequest request)
        {
            var student = await personsApplicationService.AddPersonAsync(mapper.Map<CreatePersonModel>(request), HttpContext.RequestAborted);
            return mapper.Map<PersonShortResponse>(student);
        }

        [HttpPut]
        public async Task UpdatePersonAsync(UpdatePersonRequest request)
        {
            await personsApplicationService.UpdatePerson(mapper.Map<UpdatePersonModel>(request), HttpContext.RequestAborted);
        }

        [HttpDelete("{id:guid}")]
        public async Task DeletePerson(Guid id)
        {
            await personsApplicationService.DeletePersont(id, HttpContext.RequestAborted);
        }

    }
}
