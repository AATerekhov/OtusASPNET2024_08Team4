using AutoMapper;
using MassTransit;
using RoomsDesigner.Application.Messages;
using RoomsDesigner.Application.Models.Participant;
using RoomsDesigner.Application.Models.Room;
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
        public async Task<ParticipantModel?> AddParticipantAsync(CreateParticipantModel participantInfo, Guid userId, CancellationToken token = default)
        {
            var caseEntity = await caseRepository.GetCaseByIdAsync(participantInfo.CaseId, cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(participantInfo.CaseId, nameof(Case)));

            if (!caseEntity.OwnerId.Equals(userId))
                throw new ForbiddenException(FormatForbiddenErrorMessage(userId, nameof(Case)));

            if(caseEntity.Players.FirstOrDefault(x => x.UserMail.Equals(participantInfo.UserMail)) is not null)
                throw new BadRequestException(FormatBadRequestErrorMessage(participantInfo.CaseId, nameof(Participant)));

            var participant = new Participant(participantInfo.UserMail, caseEntity, string.Empty,Guid.Empty);
            caseEntity.Add(participant);

            await caseRepository.UpdateAsync(caseEntity, token);

            participant = await participanRepository.AddAsync(participant, cancellationToken: token)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(Guid.Empty, nameof(Participant)));

            return mapper.Map<ParticipantModel>(participant);
        }

        public async Task<bool> DeleteParticipant(Guid id, Guid userId, CancellationToken token = default)
        {
            var participant = await participanRepository.GetByIdAsync(x => x.Id.Equals(id), includes: nameof(Participant.Room), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Participant)));

            if (!participant.Room.OwnerId.Equals(userId))
                throw new ForbiddenException(FormatForbiddenErrorMessage(userId, nameof(Case)));

            if (await participanRepository.DeleteAsync(participant, token) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Participant)));
            return true;
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

        public async Task<IEnumerable<ParticipantModel>> GetParticipantsByEmail(string email, CancellationToken token = default)
        {
            var participants = await participanRepository.GetAllAsync(filter: x => x.UserMail.Equals(email), includes: nameof(Participant.Room), cancellationToken: token);
            return participants.Select(mapper.Map<ParticipantModel>);
        }

        public async Task<(ParticipantModel, CaseModel)?> UpdateParticipantAsync(UpdateParticipantModel participantInfo , CancellationToken token = default)
        {
            var participant = await participanRepository.GetByIdAsync(x => x.Id.Equals(participantInfo.Id), includes: nameof(Participant.Room), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(participantInfo.Id, nameof(Participant)));

            if (!participant.UserMail.Equals(participantInfo.UserMail))
                throw new ForbiddenException(FormatForbiddenErrorMessage(participantInfo.UserId, nameof(Participant)));

            participant.Update(participantInfo.UserId, participantInfo.UserMail, participantInfo.Name);
            var result = await participanRepository.UpdateAsync(entity: participant, token);

            if (result)
            {
                var message = new AddParticipantInRoomMessage()
                {
                    PartisipantId = participantInfo.Id,
                    UserMail = participantInfo.UserMail,
                    OwnerId = participantInfo.UserId,
                    CaseId = participant.Room.Id
                };

                await busControl.Publish(message, token);
            }
            return  (mapper.Map<ParticipantModel>(participant), mapper.Map<CaseModel>(participant.Room));
        }
    }
}
