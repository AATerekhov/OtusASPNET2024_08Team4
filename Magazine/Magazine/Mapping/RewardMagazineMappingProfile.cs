using AutoMapper;
using Magazine.BusinessLogic.Models.RewardMagazine;
using Magazine.Core.Domain.Magazines;
using Magazine.DataAccess.Models;
using MagazineHost.Models.Request;
using MagazineHost.Models.Response;

namespace MagazineHost.Mapping
{
    public class RewardMagazineMappingProfile : Profile
    {
        public RewardMagazineMappingProfile()
        {
            CreateMap<RewardMagazine, RewardMagazineResponse>();
            CreateMap<RewardMagazine, RewardMagazineShortResponse>();
            CreateMap<RewardMagazineFilterRequest, RewardMagazineFilterDto>();
            CreateMap<RewardMagazineFilterDto, RewardMagazineFilterModel>();
            CreateMap<CreateOrEditRewardMagazineRequest, CreateOrEditRewardMagazineDto>();
            CreateMap<CreateOrEditRewardMagazineDto, RewardMagazine>()
              .ForMember(j => j.Lines, opt => opt.Ignore())
              .ForMember(j => j.MagazineOwner, opt => opt.Ignore())
              .ForMember(j => j.Id, opt => opt.Ignore());
        }
    }
}
