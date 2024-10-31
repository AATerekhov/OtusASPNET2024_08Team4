using AutoMapper;
using BookOfHabits.Requests.Habit;
using BookOfHabits.Responses.Habit;
using BookOfHabitsMicroservice.Application.Models.Habit;

namespace BookOfHabits.Mapping
{
    public class HabitMapping : Profile
    {
        public HabitMapping()
        {
            CreateMap<CreateHabitRequest, CreateHabitModel>();
            CreateMap<UpdateHabitRequest, HabitModel>();
            CreateMap<HabitModel, HabitShortResponse>();
            CreateMap<HabitModel, HabitDetailedResponse>();
        }
    }
}
