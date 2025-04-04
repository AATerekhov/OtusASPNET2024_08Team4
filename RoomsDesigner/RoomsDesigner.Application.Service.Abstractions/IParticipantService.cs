using RoomsDesigner.Application.Models.Participant;

namespace RoomsDesigner.Application.Service.Abstractions
{
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantModel>> GetAllParticipantsByCaseAsync(Guid caseId,CancellationToken token = default);
        Task<ParticipantModel?> GetParticipantByIdAsync(Guid id, CancellationToken token = default);
        Task<ParticipantModel?> AddParticipantAsync(CreateParticipantModel roomInfo, CancellationToken token = default);
        Task UpdateParticipant(UpdateParticipantModel roomInfo, CancellationToken token = default);
        Task DeleteParticipant(Guid id, CancellationToken token = default);
    }
}
