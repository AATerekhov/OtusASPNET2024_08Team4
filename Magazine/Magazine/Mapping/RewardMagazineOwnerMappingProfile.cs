using AutoMapper;
using Magazine.BusinessLogic.Models.RewardMagazineOwner;
using Magazine.Core.Domain.Administration;
using Magazine.DataAccess.Models;
using MagazineHost.Models.Request;
using MagazineHost.Models.Response;

namespace MagazineHost.Mapping
{
    public class RewardMagazineOwnerMappingProfile : Profile
    {
        public RewardMagazineOwnerMappingProfile()
        {
            CreateMap<RewardMagazineOwner, RewardMagazineOwnerResponse>();
            CreateMap<RewardMagazineOwner, RewardMagazineOwnerShortResponse>();
            CreateMap<RewardMagazineOwnerFilterRequest, RewardMagazineOwnerFilterDto>();
            CreateMap<RewardMagazineOwnerFilterDto, RewardMagazineOwnerFilterModel>();
            CreateMap<CreateOrEditRewardMagazineOwnerRequest, CreateOrEditRewardMagazineOwnerDto>();
            CreateMap<CreateOrEditRewardMagazineOwnerDto, RewardMagazineOwner>()
                  .ForMember(jw => jw.Magazines, opt => opt.Ignore())
                  .ForMember(jw => jw.Id, opt => opt.Ignore());

        }
    }
}
