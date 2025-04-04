using BookOfHabitsMicroservice.Application.Models.Room;
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
            var roomInfo = new CreateRoomModel() 
            {
                Id = context.Message.Id,
                Name = context.Message.Name,
                ManagerId = context.Message.OwnerId,
                CreateDate = DateTime.UtcNow
            };
            var manager = await personRepository.GetByIdAsync(x => x.Id.Equals(roomInfo.ManagerId), includes: "_rooms", cancellationToken: context.CancellationToken);
            if (manager is null)
            {
                var personItem = new Person(roomInfo.ManagerId, new PersonName($"{roomInfo.Name}Owner"));
                manager = await personRepository.AddAsync(personItem, context.CancellationToken);
            }

            Room? roomEntity = await roomRepository.GetByIdAsync(filter: x => x.Id.Equals(roomInfo.Id), cancellationToken: context.CancellationToken);
            if (roomEntity is not null)
                throw new BadRequestException(BadRequestEntityExistsMessage(roomInfo.Id, nameof(Room)));

            var room = new Room(roomInfo.Id, manager, new RoomName(roomInfo.Name), roomInfo.CreateDate, roomInfo.CreateDate);
            await personRepository.UpdateAsync(entity: manager, cancellationToken: context.CancellationToken);
            room = await roomRepository.AddAsync(entity: room, cancellationToken: context.CancellationToken)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(roomInfo.Id, nameof(Room)));
        }
    }
}
