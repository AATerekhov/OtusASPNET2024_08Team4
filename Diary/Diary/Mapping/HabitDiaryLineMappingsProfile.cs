using AutoMapper;
using Diary.BusinessLogic.Models.HabitDiaryLine;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Diary;
using Diary.DataAccess.Models;
using Diary.Models.Request;
using Diary.Models.Response;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using Diary.BusinessLogic.Helpers;

namespace Diary.Mapping
{
    public class HabitDiaryLineMappingsProfile : Profile
    {
        public HabitDiaryLineMappingsProfile()
        {
            CreateMap<HabitDiaryLine, HabitDiaryLineResponse>();
            CreateMap<HabitDiaryLineFilterRequest, HabitDiaryLineFilterDto>();
            CreateMap<HabitDiaryLineFilterDto, HabitDiaryLineFilterModel>();
            CreateMap<CreateHabitDiaryLineRequest, CreateHabitDiaryLineDto>();
            CreateMap<EditHabitDiaryLineRequest, EditHabitDiaryLineDto>();
            CreateMap<CreateHabitDiaryLineDto, HabitDiaryLine>()
              .ForMember(hl => hl.CreatedDate, opt => opt.Ignore())
              .ForMember(hl => hl.Diary, opt => opt.Ignore())
              .ForMember(hl => hl.Id, opt => opt.Ignore())
              .ForMember(hl => hl.ModifiedDate, opt =>
                opt.MapFrom(src => DateTimeHelper.ToDateTime(src.ModifiedDate, DateTimeHelper.DateFormat).ToUniversalTime()));
        }
    }
}
