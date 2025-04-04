using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsDesigner.Api.Infrastructure.ModelBinding;
using RoomsDesigner.Api.Requests.Case;
using RoomsDesigner.Api.Responses.Case;
using RoomsDesigner.Application.Models.Room;
using RoomsDesigner.Application.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RoomsDesigner.Controllers
{
    /// <summary>
    /// Room
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class CasesController(ICaseService caseService,
        ILaunchService launchService,
        IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CaseShortResponse>> GetAllRooms()
        {
            IEnumerable<CaseModel> rooms = await caseService.GetAllRoomsAsync(HttpContext.RequestAborted);
            return rooms.Select(mapper.Map<CaseShortResponse>);
        }

        [HttpGet("owner")]
        public async Task<IEnumerable<CaseShortResponse>> GetRooms()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            IEnumerable<CaseModel> rooms = await caseService.GetRoomsAsync(new Guid(userId), HttpContext.RequestAborted);
            return rooms.Select(mapper.Map<CaseShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<CaseDetailedResponse> GetRoomById(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var room = await caseService.GetRoomByIdAsync(id, new Guid(userId), HttpContext.RequestAborted);            
            return mapper.Map<CaseDetailedResponse>(room);
        }

        [HttpPost]
        public async Task<CaseShortResponse> CreateRoom(
            [ModelBinder(BinderType =typeof(CaseOwnerParametersBinder))]
            CreateCaseRequest request)
        {            
            var room = await caseService.AddRoomAsync(mapper.Map<CreateCaseModel>(request), HttpContext.RequestAborted);
            return mapper.Map<CaseShortResponse>(room);
        }

        [HttpPut]
        public async Task<bool> UpdateRoomAsync(
            [ModelBinder(BinderType =typeof(CaseUpdateOwnerParametersBinder))]
            UpdateCaseRequest request)
        {
           return await caseService.UpdateRoom(mapper.Map<UpdateCaseModel>(request), HttpContext.RequestAborted);
        }

        [HttpDelete("{id:guid}")]
        public async Task<bool> DeletRoom(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await caseService.DeleteRoom(id, new Guid(userId), HttpContext.RequestAborted);
            return result;
        }

        [HttpPost("launch")]
        public async Task LaunchCase(LaunchRequest request) =>
            await launchService.StartingCase(mapper.Map<LaunchModel>(request), HttpContext.RequestAborted);
    }
}
