using AutoMapper;
using RoomsDesigner.Api.Requests.Participant;
using RoomsDesigner.Api.Responses.Participant;
using RoomsDesigner.Application.Models.Participant;
using RoomsDesigner.Domain.Entity;

namespace RoomsDesigner.Api.Mapping
{
    public class PartisipantMapping : Profile
    {
        public PartisipantMapping()
        {
            CreateMap<CreateParticipantRequest, CreateParticipantModel>();
            CreateMap<UpdateParticipantRequest, UpdateParticipantModel>();
            CreateMap<ParticipantModel, ParticipantDetailedResponse>();
            CreateMap<ParticipantModel, ParticipantShortResponse>();
        }
    }
}
