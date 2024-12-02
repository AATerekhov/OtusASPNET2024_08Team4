
using Diary.Core.Domain.Administration;
using Diary.Models.Response;
using System.Linq;
using AutoMapper;
using Diary.Models.Request;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.DataAccess.Models;
using Diary.BusinessLogic.Models.JournalOwner;


namespace Diary.Mapping
{
    public class HabitDiaryOwnerMappingsProfile : Profile
    {
        public HabitDiaryOwnerMappingsProfile()
        {
            CreateMap<HabitDiaryOwner, HabitDiaryOwnerResponse>();
            CreateMap<HabitDiaryOwner, HabitDiaryOwnerShortResponse>();
            CreateMap<HabitDiaryOwnerFilterRequest, HabitDiaryOwnerFilterDto>();
            CreateMap<HabitDiaryOwnerFilterDto, HabitDiaryOwnerFilterModel>();
            CreateMap<CreateOrEditHabitDiaryOwnerRequest, CreateOrEditHabitDiaryOwnerDto>();
            CreateMap<CreateOrEditHabitDiaryOwnerDto, HabitDiaryOwner>()
                  .ForMember(jw => jw.Diaries, opt => opt.Ignore())
                  .ForMember(jw => jw.Id, opt => opt.Ignore());

        }
  
    }
}
