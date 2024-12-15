using RoomsDesigner.Application.Models.Participant;
using RoomsDesigner.Application.Service.Abstractions;

namespace RoomsDesigner.Application.Services.Implementations
{
    public class ParticipantService() : BaseService, IParticipantService
    {
        public Task<ParticipantModel?> AddParticipantAsync(CreateParticipantModel roomInfo, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteParticipant(Guid id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParticipantModel>> GetAllParticipantsByCaseAsync(Guid caseId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<ParticipantModel?> GetParticipantByIdAsync(Guid id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateParticipant(UpdateParticipantModel roomInfo, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
