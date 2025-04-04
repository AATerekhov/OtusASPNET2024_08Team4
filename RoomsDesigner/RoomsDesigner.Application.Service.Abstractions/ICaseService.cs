using RoomsDesigner.Application.Models.Room;

namespace RoomsDesigner.Application.Service.Abstractions
{
    public interface ICaseService
    {
        Task<IEnumerable<CaseModel>> GetAllRoomsAsync(CancellationToken token = default);
        Task<CaseModel?> GetRoomByIdAsync(Guid id, CancellationToken token = default);
        Task<CaseModel?> AddRoomAsync(CreateCaseModel roomInfo, CancellationToken token = default);
        Task UpdateRoom(UpdateCaseModel roomInfo, CancellationToken token = default);
        Task DeleteRoom(Guid id, CancellationToken token = default);
    }
}
