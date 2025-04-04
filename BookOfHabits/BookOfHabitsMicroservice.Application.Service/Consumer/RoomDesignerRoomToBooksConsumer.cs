using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Implementations.Base;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Domain.ValueObjects;
using MassTransit;
using RoomsDesigner.Application.Messages;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.Consumer
{
    public class RoomDesignerRoomToBooksConsumer(IRoomRepository roomRepository, IRepository<Person, Guid> personRepository) : BaseService, IConsumer<CreateRoomMessage>
    {
        public async Task Consume(ConsumeContext<CreateRoomMessage> context)
        {
            var messageInfo = context.Message;            

            Room? room = await roomRepository.GetByIdAsync(filter: x => x.Id.Equals(messageInfo.CaseId), cancellationToken: context.CancellationToken);
            if (room is not null)
                throw new BadRequestException(BadRequestEntityExistsMessage(messageInfo.CaseId, nameof(Room)));

            var manager = new Person(new PersonName(messageInfo.UserMail), messageInfo.OwnerId);

            room = new Room(messageInfo.CaseId, manager, new RoomName(messageInfo.CaseName), DateTime.UtcNow, DateTime.UtcNow);

            await personRepository.AddAsync(manager, context.CancellationToken);

            room = await roomRepository.AddAsync(entity: room, cancellationToken: context.CancellationToken)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(messageInfo.CaseId, nameof(Room)));
        }
    }
}
