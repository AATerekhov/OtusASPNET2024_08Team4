using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AutoMapper;
using RoomsDesigner.Api.Responses.Room;
using RoomsDesigner.Application.Models.Room;

namespace RoomsDesigner.Controllers
{
	/// <summary>
	/// Room
	/// </summary>
	[ApiController]
	[Route("api/v1/[controller]")]
	public class RoomController(IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CaseShortResponse>> GetAllRooms()
        {
            IEnumerable<RoomModel> rooms = await roomsApplicationService.GetAllRoomsAsync(HttpContext.RequestAborted);
            return rooms.Select(mapper.Map<CaseShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<CaseDetailedResponse> GetRoomById(Guid id)
        {
            var room = await roomsApplicationService.GetRoomByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<CaseDetailedResponse>(room);
        }

        [HttpPost]
        public async Task<CaseShortResponse> CreateRoom(CreateRoomRequest request)
        {
            var student = await roomsApplicationService.AddRoomAsync(mapper.Map<CreateRoomModel>(request), HttpContext.RequestAborted);
            return mapper.Map<CaseShortResponse>(student);
        }

        [HttpPut]
        public async Task UpdateRoomAsync(UpdateRoomRequest request)
        {
            await roomsApplicationService.UpdateRoom(mapper.Map<UpdateRoomModel>(request), HttpContext.RequestAborted);
        }

        [HttpDelete("{id:guid}")]
        public async Task DeletRoom(Guid id)
        {
            await roomsApplicationService.DeleteRoom(id, HttpContext.RequestAborted);
        }
    }
}
