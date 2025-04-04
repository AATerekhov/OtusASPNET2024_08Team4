using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsDesigner.Api.Requests.Participant;
using RoomsDesigner.Api.Responses.Case;
using RoomsDesigner.Api.Responses.Participant;
using RoomsDesigner.Application.Models.Participant;
using RoomsDesigner.Application.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YamlDotNet.Core;

namespace RoomsDesigner.Api.Controllers
{
    /// <summary>
    /// User
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
	public class ParticipantsController(IParticipantService participantService,ICaseService caseService, IMapper mapper) : ControllerBase
    {
        [HttpGet("case/{id:guid}")]
        public async Task<IEnumerable<ParticipantShortResponse>> GetParticipantsByCase([FromRoute]Guid id)
        {
            IEnumerable<ParticipantModel> persons = await participantService.GetAllParticipantsByCaseAsync(id,HttpContext.RequestAborted);
            return persons.Select(mapper.Map<ParticipantShortResponse>);
        }

        [HttpGet("owner")]
        [Authorize]
        public async Task<IEnumerable<ParticipantDetailedResponse>> GetParticipants()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            IEnumerable<ParticipantModel> participants = await participantService.GetParticipantsByEmail(email, HttpContext.RequestAborted);

            var cases = await caseService.GetAllRoomsAsync(HttpContext.RequestAborted);
            var casesShorts = cases.Select(mapper.Map<CaseShortResponse>);

            var participantsDetail = participants.Select(mapper.Map<ParticipantDetailedResponse>).ToList();

            participantsDetail.ForEach(x => x.Case = casesShorts.FirstOrDefault(c => c.Id.Equals(x.CaseId)));

            return participantsDetail;
        }


        [HttpGet("check/{id:guid}")]
        [Authorize]
        public async Task<ParticipantDetailedResponse> GetParticipantCheck(Guid id)
        {
            UpdateParticipantModel updateModel = new UpdateParticipantModel()
            {
                Id = id,
                UserId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value),
                UserMail = User.FindFirst(ClaimTypes.Email)?.Value,
                Name = User.FindFirst(ClaimTypes.GivenName)?.Value
            };
            var result = await participantService.UpdateParticipantAsync(updateModel, HttpContext.RequestAborted);
            var responce = mapper.Map<ParticipantDetailedResponse>(result.Value.Item1);

            var caseResponce = mapper.Map<CaseShortResponse>(result.Value.Item2);
            responce.Case = caseResponce;
            return responce;
        }

        [HttpGet("{id:guid}")]
        public async Task<ParticipantDetailedResponse> GetParticipantById(Guid id)
        {
            var person = await participantService.GetParticipantByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<ParticipantDetailedResponse>(person);
        }

        [HttpPost]
        [Authorize]
        public async Task<ParticipantDetailedResponse> AddParticipant([FromBody]CreateParticipantRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var caseEntity = await caseService.GetRoomByIdAsync(request.CaseId, HttpContext.RequestAborted);

            var patricipant = await participantService.AddParticipantAsync(mapper.Map<CreateParticipantModel>(request), new Guid(userId), HttpContext.RequestAborted);
            var result = mapper.Map<ParticipantDetailedResponse>(patricipant);
            result.Case = mapper.Map<CaseShortResponse>(caseEntity);
            return result;
        }


        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<bool> DeleteParticipant(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await participantService.DeleteParticipant(id, new Guid(userId), HttpContext.RequestAborted);
            return true;
        }

    }
}
