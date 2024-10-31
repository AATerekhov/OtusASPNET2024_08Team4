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
            CreateMap<UpdateHabitRequest, UpdateHabitModel>();
            CreateMap<HabitModel, HabitShortResponse>();
            CreateMap<HabitModel, HabitDetailedResponse>();            

            CreateMap<DelayRequest, UpdateDelayModel>();
            CreateMap<RepetitionRequest, UpdateRepetitionModel>();
            CreateMap<TimeResetIntervalRequest, UpdateTimeResetIntervalModel>();
            CreateMap<DelayModel, DelayRequest>();
            CreateMap<RepetitionModel, RepetitionRequest>();
            CreateMap<TimeResetIntervalModel, TimeResetIntervalRequest>();

            CreateMap<InstallCardRequest, InstallCardModel>();
        }
    }
}
