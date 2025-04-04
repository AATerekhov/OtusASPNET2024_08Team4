using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Implementations.Base;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Domain.ValueObjects;
using MassTransit;
using Microsoft.Extensions.Logging;
using RoomsDesigner.Application.Messages;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.Consumer
{
    public class ParticipantAddedInRoomConsumer(IRoomRepository roomRepository,
        IRepository<Person, Guid> personRepository,
        ILogger<ParticipantAddedInRoomConsumer> logger) : BaseService, IConsumer<AddParticipantInRoomMessage>
    {
        public async Task Consume(ConsumeContext<AddParticipantInRoomMessage> context)
        {
            var personInfo = context.Message;
            Room? room = await roomRepository.GetByIdAsync(filter: x => x.Id.Equals(personInfo.CaseId), asNoTracking: true, cancellationToken: context.CancellationToken)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(personInfo.CaseId, nameof(Room)));

            Person ? person = await personRepository.GetByIdAsync(filter: x => x.Id.Equals(personInfo.PartisipantId), cancellationToken: context.CancellationToken);
            if (person is not null)
            {
                logger.LogInformation(BadRequestEntityExistsMessage(personInfo.PartisipantId, nameof(Person)));
            }
            else 
            {
                person = new Person(personInfo.PartisipantId, new PersonName(personInfo.UserMail), personInfo.OwnerId);
                person = await personRepository.AddAsync(person, context.CancellationToken)
                    ?? throw new BadRequestException(FormatBadRequestErrorMessage(personInfo.PartisipantId, nameof(Person)));
            }          
        }
    }
}
