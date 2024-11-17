using AutoMapper;
using Diary.BusinessLogic.Models.HabitDiaryLine;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Diary;
using Diary.DataAccess.Models;
using Diary.Models.Request;
using Diary.Models.Response;

namespace Diary.Mapping
{
    public class HabitDiaryLineMappingsProfile : Profile
    {
        public HabitDiaryLineMappingsProfile()
        {
            CreateMap<HabitDiaryLine, HabitDiaryLineResponse>();
            CreateMap<HabitDiaryLineFilterRequest, HabitDiaryLineFilterDto>();
            CreateMap<HabitDiaryLineFilterDto, HabitDiaryLineFilterModel>();
            CreateMap<CreateOrEditHabitDiaryLineRequest, CreateOrEditHabitDiaryLineDto>();
            CreateMap<CreateOrEditHabitDiaryLineDto, HabitDiaryLine>()
              .ForMember(j => j.CreatedDate, opt => opt.Ignore())
              .ForMember(j => j.ModifiedDate, opt => opt.Ignore())
              .ForMember(j => j.Diary, opt => opt.Ignore())
              .ForMember(j => j.Id, opt => opt.Ignore());
        }
    }
}
