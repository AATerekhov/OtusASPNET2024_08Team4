using AutoMapper;
using Diary.BusinessLogic.Helpers;
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
    public class HabitStateMappingsProfile : Profile
    {
        public HabitStateMappingsProfile()
        {
            CreateMap<HabitState, HabitStateResponse>();
            CreateMap<CreateHabitStateRequest, CreateHabitStateDto>();
            CreateMap<EditHabitStateRequest, EditHabitStateDto>();
            CreateMap<CreateHabitStateDto, HabitState>()
              .ForMember(j => j.Habit, opt => opt.Ignore())
              .ForMember(j => j.Id, opt => opt.Ignore())
              .ForMember(hl => hl.ModifiedDate, opt =>
                opt.MapFrom(src => DateTimeHelper.ToDateTime(src.ModifiedDate, DateTimeHelper.DateFormat).ToUniversalTime()));
        }
    }
}
