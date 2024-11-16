using AutoMapper;
using BookOfHabits.Requests.Person;
using BookOfHabits.Requests.Room;
using BookOfHabits.Responses.Person;
using BookOfHabits.Responses.Room;
using BookOfHabitsMicroservice.Application.Models.Person;
using BookOfHabitsMicroservice.Application.Models.Room;

namespace BookOfHabits.Mapping
{
    public class RoomMapping : Profile
    {
        public RoomMapping() 
        {
            CreateMap<CreateRoomRequest, CreateRoomModel>();
            CreateMap<UpdateRoomRequest, UpdateRoomModel>();
            CreateMap<RoomModel, RoomShortResponse>();
            CreateMap<RoomModel, RoomDetailedResponse>();
        }
    }
}
