using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Room;
using BookOfHabitsMicroservice.Domain.Entity;
using RoomsDesigner.Application.Messages;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.Mapping
{
    public class RoomMapping: Profile
    {
        public RoomMapping()
        {
            CreateMap<Room, RoomModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Name));
        }
    }
}
