using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using RoomsDesigner.Api.Responses.Participant;
using AutoMapper;
using RoomsDesigner.Api.Requests.Participant;

namespace RoomsDesigner.Api.Controllers
{
	/// <summary>
	/// User
	/// </summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ParticipantController(IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ParticipantShortResponse>> GetAllPersons()
        {
            IEnumerable<ParticipantModel> persons = await personsApplicationService.GetAllPersonsAsync(HttpContext.RequestAborted);
            return persons.Select(mapper.Map<ParticipantShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<ParticipantDetailedResponse> GetParticipantById(Guid id)
        {
            var person = await personsApplicationService.GetPersonByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<ParticipantDetailedResponse>(person);
        }

        [HttpPost]
        public async Task<ParticipantShortResponse> AddParticipant(CreateParticipantRequest request)
        {
            var student = await personsApplicationService.AddPersonAsync(mapper.Map<CreateParticipantModel>(request), HttpContext.RequestAborted);
            return mapper.Map<ParticipantShortResponse>(student);
        }

        [HttpPut]
        public async Task UpdateParticipantAsync(UpdateParticipantRequest request)
        {
            await personsApplicationService.UpdatePerson(mapper.Map<UpdateParticipantModel>(request), HttpContext.RequestAborted);
        }

        [HttpDelete("{id:guid}")]
        public async Task DeleteParticipant(Guid id)
        {
            await personsApplicationService.DeletePersont(id, HttpContext.RequestAborted);
        }

    }
}
