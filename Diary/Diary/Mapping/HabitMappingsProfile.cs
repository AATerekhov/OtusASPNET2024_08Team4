using AutoMapper;
using Diary.BusinessLogic.Models.Habit;
using Diary.BusinessLogic.Models.HabitDiary;
using Diary.BusinessLogic.Models.HabitState;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Diary;
using Diary.Core.Domain.Habits;
using Diary.DataAccess.Models;
using Diary.Models.Request;
using Diary.Models.Response;

namespace Diary.Mapping
{
    public class HabitMappingsProfile : Profile
    {
        public HabitMappingsProfile()
        {
            CreateMap<Habit, HabitShortResponse>();
            CreateMap<Habit, HabitResponse>();
            CreateMap<CreateHabitRequest, CreateHabitDto>();
            CreateMap<EditHabitRequest, EditHabitDto>();
            CreateMap<CreateHabitDto, Habit>()
              .ForMember(j => j.HabitStates, opt => opt.Ignore())
              .ForMember(j => j.Diary, opt => opt.Ignore())
              .ForMember(j => j.Id, opt => opt.Ignore());
        }
    }
}
