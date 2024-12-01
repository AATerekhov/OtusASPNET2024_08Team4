using AutoMapper;
using Diary.BusinessLogic.Models.HabitDiaryLine;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Diary;
using Diary.DataAccess.Models;
using Diary.Helpers;
using Diary.Models.Request;
using Diary.Models.Response;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

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
              .ForMember(hl => hl.CreatedDate, opt => opt.Ignore())
              .ForMember(hl => hl.Diary, opt => opt.Ignore())
              .ForMember(hl => hl.Id, opt => opt.Ignore())
              .ForMember(hl => hl.ModifiedDate, opt =>
                opt.MapFrom(src => DateTimeHelper.ToDateTime(src.ModifiedDate, DateTimeHelper.DateFormat).ToUniversalTime()));
        }
    }
}
