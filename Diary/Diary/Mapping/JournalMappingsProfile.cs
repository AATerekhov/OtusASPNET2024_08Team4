using AutoMapper;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.JournalOwner;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.UserJournals;
using Diary.DataAccess.Models;
using Diary.Models.Request;
using Diary.Models.Response;

namespace Diary.Mapping
{
    public class JournalMappingsProfile:Profile
    {
        public JournalMappingsProfile()
        {
            CreateMap<Journal, JournalResponse>();
            CreateMap<JournalFilterRequest, JournalFilterDto>();
            CreateMap<JournalFilterDto, JournalFilterModel>();
            CreateMap<CreateOrEditJournalRequest, CreateOrEditJournalDto>();
            CreateMap<CreateOrEditJournalDto, Journal>()
              .ForMember(j => j.JournalLines, opt => opt.Ignore())
              .ForMember(j => j.JournalOwner, opt => opt.Ignore())
              .ForMember(j => j.Id, opt => opt.Ignore());
        }
    }
}
