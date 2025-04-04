using BookOfHabitsMicroservice.Application.Models.Room;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions
{
    public interface IRoomsApplicationService
    {
        Task<IEnumerable<RoomModel>> GetAllRoomsAsync(CancellationToken token = default);
        Task<RoomModel?> GetRoomByIdAsync(Guid id, Guid userId, CancellationToken token = default);
        Task<RoomModel?> AddRoomAsync(CreateRoomModel roomInfo, CancellationToken token = default);
        Task UpdateRoom(UpdateRoomModel roomInfo, CancellationToken token = default);
        Task DeleteRoom(Guid id, CancellationToken token = default);
    }
}
