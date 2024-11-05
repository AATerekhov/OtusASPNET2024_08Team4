
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
    public class JournalOwnerMappingsProfile : Profile
    {
        public JournalOwnerMappingsProfile()
        {
            CreateMap<JournalOwner, JournalOwnerResponse>();
            CreateMap<JournalOwnerFilterRequest, JournalOwnerFilterDto>();
            CreateMap<JournalOwnerFilterDto, JournalOwnerFilterModel>();
            CreateMap<CreateOrEditJournalOwnerRequest, CreateOrEditJournalOwnerDto>();
            CreateMap<CreateOrEditJournalOwnerDto, JournalOwner>()
                  .ForMember(jw => jw.Journals, opt => opt.Ignore())
                  .ForMember(jw => jw.Id, opt => opt.Ignore());

        }
  
    }
}
