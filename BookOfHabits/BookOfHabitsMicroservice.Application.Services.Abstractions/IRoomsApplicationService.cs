using BookOfHabitsMicroservice.Application.Models.Person;
using BookOfHabitsMicroservice.Application.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions
{
    public interface IRoomsApplicationService
    {
        Task<IEnumerable<RoomModel>> GetAllRoomsAsync(CancellationToken token = default);
        Task<RoomModel?> GetRoomByIdAsync(Guid id, CancellationToken token = default);
        Task<RoomModel?> AddRoomAsync(CreateRoomModel roomInfo, CancellationToken token = default);
        Task UpdateRoom(UpdateRoomModel roomInfo, CancellationToken token = default);
        Task DeleteRoom(Guid id, CancellationToken token = default);
    }
}
