using MassTransit;
using RoomsDesigner.Application.Messages;
using RoomsDesigner.Application.Models.Room;
using RoomsDesigner.Application.Service.Abstractions;
using RoomsDesigner.Application.Service.Abstractions.Exceptions;
using RoomsDesigner.Domain.Entity;
using RoomsDesigner.Domain.Repository.Abstractions;

namespace RoomsDesigner.Application.Services.Implementations
{
    public class LaunchService(IParticipantRepository participanRepository,
        ICaseRepository caseRepository,
        IBusControl busControl) : BaseService, ILaunchService
    {
        public async Task StartingCase(LaunchModel launchInfo, CancellationToken token = default)
        {
            Case? caseEmtity = await caseRepository.GetByIdAsync(filter: s => s.Id.Equals(launchInfo.Id),includes: "_players", cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(launchInfo.Id, nameof(Case)));
            if (!caseEmtity.OwnerId.Equals(launchInfo.OwnerId))
                throw new BadRequestException("The user is not the owner this room.");

            var magazineMessage = new StartMagazineMessage()
            {
                RoomId = caseEmtity.Id,
                Description = caseEmtity.Name,
                MagazineOwnerId = caseEmtity.OwnerId,
            };

            await busControl.Publish(magazineMessage, token);

            caseEmtity.Players.ToList().ForEach(async p => {
                await busControl.Publish(new StartDiaryMessage()
                {
                    RoomId = caseEmtity.Id,
                    Description = caseEmtity.Name,
                    DiaryOwnerId = p.Id
                }, token);
            });
        }
    }
}
