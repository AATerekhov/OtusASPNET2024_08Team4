using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsDesigner.Api.Requests.Participant;
using RoomsDesigner.Api.Responses.Participant;
using RoomsDesigner.Application.Models.Participant;
using RoomsDesigner.Application.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomsDesigner.Api.Controllers
{
    /// <summary>
    /// User
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
	public class ParticipantController(IParticipantService participantService, IMapper mapper) : ControllerBase
    {
        [HttpGet("case/{id:guid}")]
        public async Task<IEnumerable<ParticipantShortResponse>> GetAllPersons(Guid caseId)
        {
            IEnumerable<ParticipantModel> persons = await participantService.GetAllParticipantsByCaseAsync(caseId,HttpContext.RequestAborted);
            return persons.Select(mapper.Map<ParticipantShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<ParticipantDetailedResponse> GetParticipantById(Guid id)
        {
            var person = await participantService.GetParticipantByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<ParticipantDetailedResponse>(person);
        }

        [HttpPost]
        public async Task<ParticipantShortResponse> AddParticipant(CreateParticipantRequest request)
        {
            var student = await participantService.AddParticipantAsync(mapper.Map<CreateParticipantModel>(request), HttpContext.RequestAborted);
            return mapper.Map<ParticipantShortResponse>(student);
        }

        [HttpPut]
        public async Task UpdateParticipantAsync(UpdateParticipantRequest request)
        {
            await participantService.UpdateParticipant(mapper.Map<UpdateParticipantModel>(request), HttpContext.RequestAborted);
        }

        [HttpDelete("{id:guid}")]
        public async Task DeleteParticipant(Guid id)
        {
            await participantService.DeleteParticipant(id, HttpContext.RequestAborted);
        }

    }
}
