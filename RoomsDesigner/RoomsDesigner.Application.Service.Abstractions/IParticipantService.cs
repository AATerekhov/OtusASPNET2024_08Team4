using RoomsDesigner.Application.Models.Participant;
using RoomsDesigner.Application.Models.Room;

namespace RoomsDesigner.Application.Service.Abstractions
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantModel>> GetAllParticipantsByCaseAsync(Guid caseId,CancellationToken token = default);
        Task<IEnumerable<ParticipantModel>> GetParticipantsByEmail(string email, CancellationToken token = default);
        Task<ParticipantModel?> GetParticipantByIdAsync(Guid id, CancellationToken token = default);
        Task<ParticipantModel?> AddParticipantAsync(CreateParticipantModel roomInfo, Guid userId, CancellationToken token = default);
        Task<(ParticipantModel, CaseModel)?> UpdateParticipantAsync(UpdateParticipantModel roomInfo, CancellationToken token = default);
        Task<bool> DeleteParticipant(Guid id, Guid userId, CancellationToken token = default);
    }
}
