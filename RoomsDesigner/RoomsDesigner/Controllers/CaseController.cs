using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsDesigner.Api.Requests.Case;
using RoomsDesigner.Api.Responses.Case;
using RoomsDesigner.Application.Models.Room;
using RoomsDesigner.Application.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomsDesigner.Controllers
{
    /// <summary>
    /// Room
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CaseController(ICaseService caseService,
        ILaunchService launchService,
        IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CaseShortResponse>> GetAllRooms()
        {
            IEnumerable<CaseModel> rooms = await caseService.GetAllRoomsAsync(HttpContext.RequestAborted);
            return rooms.Select(mapper.Map<CaseShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<CaseDetailedResponse> GetRoomById(Guid id)
        {
            var room = await caseService.GetRoomByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<CaseDetailedResponse>(room);
        }

        [HttpPost]
        public async Task<CaseShortResponse> CreateRoom(CreateCaseRequest request)
        {
            var student = await caseService.AddRoomAsync(mapper.Map<CreateCaseModel>(request), HttpContext.RequestAborted);
            return mapper.Map<CaseShortResponse>(student);
        }

        [HttpPut]
        public async Task UpdateRoomAsync(UpdateCaseRequest request)
        {
            await caseService.UpdateRoom(mapper.Map<UpdateCaseModel>(request), HttpContext.RequestAborted);
        }

        [HttpDelete("{id:guid}")]
        public async Task DeletRoom(Guid id)
        {
            await caseService.DeleteRoom(id, HttpContext.RequestAborted);
        }

        [HttpPost("launch")]
        public async Task LaunchCase(LaunchRequest request) =>
            await launchService.StartingCase(mapper.Map<LaunchModel>(request), HttpContext.RequestAborted);
    }
}
