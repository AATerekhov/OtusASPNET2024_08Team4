using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Room;
using BookOfHabitsMicroservice.Domain.Entity;

namespace BookOfHabitsMicroservice.Application.Services.Mapping
{
    public class RoomMapping: Profile
    {
        public RoomMapping()
        {
            CreateMap<Room, RoomModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Name));
        }
    }
}
