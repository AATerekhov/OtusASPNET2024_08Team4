using AutoMapper;
using BookOfHabits.Requests.Room;
using BookOfHabits.Responses.Room;
using BookOfHabitsMicroservice.Application.Models.Room;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookOfHabits.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoomsController(IRoomsApplicationService roomsApplicationService,
                                 IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<RoomShortResponse>> GetAllRooms()
        {
            IEnumerable<RoomModel> rooms = await roomsApplicationService.GetAllRoomsAsync(HttpContext.RequestAborted);
            return rooms.Select(mapper.Map<RoomShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<RoomDetailedResponse> GetRoomById(Guid id)
        {
            var room = await roomsApplicationService.GetRoomByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<RoomDetailedResponse>(room);
        }

        [HttpPost]
        public async Task<RoomShortResponse> CreateRoom(CreateRoomRequest request)
        {
            var student = await roomsApplicationService.AddRoomAsync(mapper.Map<CreateRoomModel>(request), HttpContext.RequestAborted);
            return mapper.Map<RoomShortResponse>(student);
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
