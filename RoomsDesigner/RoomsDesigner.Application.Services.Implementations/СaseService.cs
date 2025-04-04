using AutoMapper;
using MassTransit;
using RoomsDesigner.Application.Messages;
using RoomsDesigner.Application.Models.Room;
using RoomsDesigner.Application.Service.Abstractions;
using RoomsDesigner.Application.Service.Abstractions.Exceptions;
using RoomsDesigner.Domain.Entity;
using RoomsDesigner.Domain.Repository.Abstractions;

namespace RoomsDesigner.Application.Services.Implementations
{
    public class СaseService(ICaseRepository caseRepository, IMapper mapper, IBusControl busControl) : BaseService, ICaseService
    {
        public async Task<CaseModel?> AddRoomAsync(CreateCaseModel roomInfo, CancellationToken token = default)
        {
            var caseEntity = new Case(roomInfo.Name, roomInfo.OwnerId);
            caseEntity = await caseRepository.AddAsync(entity: caseEntity, cancellationToken: token)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(Guid.Empty, nameof(Case)));
            await busControl.Publish(mapper.Map<CreateRoomMessage>(caseEntity),token);
            return mapper.Map<CaseModel>(caseEntity);
        }

        public async Task DeleteRoom(Guid id, CancellationToken token = default)
        {
            var caseEntity = await caseRepository.GetByIdAsync(x => x.Id.Equals(id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Case)));
            if (await caseRepository.DeleteAsync(caseEntity, token) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Case)));
        }

        public async Task<IEnumerable<CaseModel>> GetAllRoomsAsync(CancellationToken token = default)
        {
            var caseEntity = await caseRepository.GetAllAsync(cancellationToken: token);
            return caseEntity.Select(mapper.Map<CaseModel>);
        }

        public async Task<CaseModel?> GetRoomByIdAsync(Guid id, CancellationToken token = default)
        {
            var caseEntity = await caseRepository.GetCaseByIdAsync(id, cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Case)));
            return mapper.Map<CaseModel>(caseEntity);
        }

        public async Task UpdateRoom(UpdateCaseModel roomInfo, CancellationToken token = default)
        {
            var caseEntity = await caseRepository.GetByIdAsync(x => x.Id.Equals(roomInfo.Id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(roomInfo.Id, nameof(Case)));
            caseEntity.Update(roomInfo.Name,roomInfo.OwnerId);
            await caseRepository.UpdateAsync(entity: caseEntity, token);
        }
    }
}
