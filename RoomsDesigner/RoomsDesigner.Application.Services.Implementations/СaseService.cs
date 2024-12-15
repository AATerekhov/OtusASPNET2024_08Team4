using RoomsDesigner.Application.Models.Room;
using RoomsDesigner.Application.Service.Abstractions;

namespace RoomsDesigner.Application.Services.Implementations
{
    public class СaseService() : BaseService, ICaseService
    {
        public Task<CaseModel?> AddRoomAsync(CreateCaseModel roomInfo, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoom(Guid id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CaseModel>> GetAllRoomsAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<CaseModel?> GetRoomByIdAsync(Guid id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoom(UpdateCaseModel roomInfo, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
