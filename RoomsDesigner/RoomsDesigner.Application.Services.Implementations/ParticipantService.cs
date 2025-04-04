using AutoMapper;
using MassTransit;
using RoomsDesigner.Application.Messages;
using RoomsDesigner.Application.Models.Participant;
using RoomsDesigner.Application.Service.Abstractions;
using RoomsDesigner.Application.Service.Abstractions.Exceptions;
using RoomsDesigner.Domain.Entity;
using RoomsDesigner.Domain.Repository.Abstractions;

namespace RoomsDesigner.Application.Services.Implementations
{
    public class ParticipantService(IParticipantRepository participanRepository,
        ICaseRepository caseRepository,
        IMapper mapper,
        IBusControl busControl) : BaseService, IParticipantService
    {
        public async Task<ParticipantModel?> AddParticipantAsync(CreateParticipantModel participantInfo, CancellationToken token = default)
        {
            var caseEntity = await caseRepository.GetByIdAsync(filter: x => x.Id.Equals(participantInfo.CaseId), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(participantInfo.CaseId, nameof(Case)));

            var participant = new Participant(participantInfo.UserMail, caseEntity, string.Empty,Guid.Empty);
            caseEntity.Add(participant);

            await caseRepository.UpdateAsync(caseEntity, token);

            participant = await participanRepository.AddAsync(participant, cancellationToken: token)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(Guid.Empty, nameof(Participant)));

            var message = new AddParticipantInRoomMessage()
            {
                UserMail = participant.UserMail,
                CaseId = caseEntity.Id,
                Id = participant.Id
            };
            await busControl.Publish(message, token);

            return mapper.Map<ParticipantModel>(participant);
        }

        public async Task DeleteParticipant(Guid id, CancellationToken token = default)
        {
            var participant = await participanRepository.GetByIdAsync(x => x.Id.Equals(id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Participant)));
            if (await participanRepository.DeleteAsync(participant, token) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Participant)));
        }

        public async Task<IEnumerable<ParticipantModel>> GetAllParticipantsByCaseAsync(Guid caseId, CancellationToken token = default)
        {
            var caseEntity = await caseRepository.GetCaseByIdAsync(caseId, token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(caseId, nameof(Case)));

            return caseEntity.Players.Select(mapper.Map<ParticipantModel>);
        }

        public async Task<ParticipantModel?> GetParticipantByIdAsync(Guid id, CancellationToken token = default)
        {
            var participant = await participanRepository.GetParticipantByIdAsync(id, token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Participant)));
            return mapper.Map<ParticipantModel>(participant);
        }

        public async Task UpdateParticipant(UpdateParticipantModel participantInfo, CancellationToken token = default)
        {
            var participant = await participanRepository.GetByIdAsync(x => x.Id.Equals(participantInfo.Id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(participantInfo.Id, nameof(Participant)));
            participant.Update(participantInfo.UserId, participantInfo.Name, participantInfo.UserMail);
            await participanRepository.UpdateAsync(entity: participant, token);
        }
    }
}
