﻿using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Room;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Base;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Application.Services
{
    public class RoomsApplicationService(IRepository<Room, Guid> roomRepository,
                                            IRepository<Person, Guid> personRepository,
                                            IMapper mapper) : BaseService, IRoomsApplicationService
    {
        public async Task<RoomModel?> AddRoomAsync(CreateRoomModel roomInfo, CancellationToken token = default)
        {
            var manager = await personRepository.GetByIdAsync(x => x.Id.Equals(roomInfo.ManagerId), includes: "_rooms", cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(roomInfo.ManagerId, nameof(Person)));

            var room = new Room(roomInfo.Id, manager, new RoomName(roomInfo.Name), roomInfo.CreateDate, roomInfo.CreateDate);
            room = await roomRepository.AddAsync(entity: room, cancellationToken: token)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(roomInfo.Id, nameof(Room)));
            await personRepository.UpdateAsync(entity: manager, cancellationToken: token);
            return mapper.Map<RoomModel>(room);
        }

        public async Task DeleteRoom(Guid id, CancellationToken token = default)
        {
            var room = await roomRepository.GetByIdAsync(x => x.Id.Equals(id))
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Room)));
            if (await roomRepository.DeleteAsync(room) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Room)));
        }

        public async Task<IEnumerable<RoomModel>> GetAllRoomsAsync(CancellationToken token = default)
        {
            var rooms = await roomRepository.GetAllAsync(filter: x => x.IsActive.Equals(true));
            return rooms.Select(mapper.Map<RoomModel>);
        }

        public async Task<RoomModel?> GetRoomByIdAsync(Guid id, CancellationToken token = default)
        {
            var room = await roomRepository.GetByIdAsync(x => x.Id.Equals(id),
                                                            includes: $"{nameof(Room.Manager)},_habits,_bags",
                                                            asNoTracking:true,
                                                            cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Room)));

            return mapper.Map<RoomModel>(room);
        }

        public async Task UpdateRoom(UpdateRoomModel roomInfo, CancellationToken token = default)
        {
            var room = await roomRepository.GetByIdAsync(x => x.Id.Equals(roomInfo.Id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(roomInfo.Id, nameof(Room)));
            
            if (roomInfo.Name is not null)
                room.SetName(roomInfo.Name);
            room.SetActiveStatus(roomInfo.IsActive);
            await roomRepository.UpdateAsync(entity: room, token);
        }
    }
}