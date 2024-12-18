using AutoMapper;
using Magazine.BusinessLogic.Helpers;
using Magazine.BusinessLogic.Models.RewardMagazineLine;
using Magazine.Core.Domain.Magazines;
using Magazine.DataAccess.Models;
using MagazineHost.Models.Request;
using MagazineHost.Models.Response;

namespace MagazineHost.Mapping
{
    public class RewardMagazineLineMappingProfile : Profile
    {
        public RewardMagazineLineMappingProfile()
        {
            CreateMap<RewardMagazineLine, RewardMagazineLineResponse>();
            CreateMap<RewardMagazineLineFilterRequest, RewardMagazineLineFilterDto>();
            CreateMap<RewardMagazineLineFilterDto, RewardMagazineLineFilterModel>();
            CreateMap<CreateRewardMagazineLineRequest, CreateRewardMagazineLineDto>();
            CreateMap<CreateRewardMagazineLineDto, RewardMagazineLine>()
              .ForMember(hl => hl.CreatedDate, opt => opt.Ignore())
              .ForMember(hl => hl.Magazine, opt => opt.Ignore())
              .ForMember(hl => hl.Id, opt => opt.Ignore())
              .ForMember(hl => hl.ModifiedDate, opt =>
                opt.MapFrom(src => DateTimeHelper.ToDateTime(src.ModifiedDate, DateTimeHelper.DateFormat).ToUniversalTime()));
        }
    }
}
