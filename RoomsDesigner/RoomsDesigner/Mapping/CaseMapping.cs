using AutoMapper;
using RoomsDesigner.Api.Requests.Case;
using RoomsDesigner.Api.Responses.Case;
using RoomsDesigner.Application.Models.Room;

namespace RoomsDesigner.Api.Mapping
{
    public class CaseMapping : Profile
    {
        public CaseMapping()
        {
            CreateMap<UpdateCaseRequest, UpdateCaseModel>();
            CreateMap<CreateCaseRequest, CreateCaseModel>();
            CreateMap<CaseModel, CaseDetailedResponse>();
            CreateMap<CaseModel, CaseShortResponse>();
        }
    }
}
