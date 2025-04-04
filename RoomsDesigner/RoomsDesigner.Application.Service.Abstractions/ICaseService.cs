using RoomsDesigner.Application.Models.Room;

namespace RoomsDesigner.Application.Service.Abstractions
{
    public interface ICaseService
    {
        Task<IEnumerable<CaseModel>> GetAllRoomsAsync(CancellationToken token = default);
        Task<IEnumerable<CaseModel>> GetRoomsAsync(Guid ownerId, CancellationToken token = default);
        Task<CaseModel?> GetRoomByIdAsync(Guid id, Guid userId, CancellationToken token = default);
        Task<CaseModel?> GetRoomByIdAsync(Guid id, CancellationToken token = default);
        Task<CaseModel?> AddRoomAsync(CreateCaseModel roomInfo, CancellationToken token = default);
        Task<bool> UpdateRoom(UpdateCaseModel roomInfo, CancellationToken token = default);
        Task<bool> DeleteRoom(Guid id, Guid Owner, CancellationToken token = default);
    }
}
