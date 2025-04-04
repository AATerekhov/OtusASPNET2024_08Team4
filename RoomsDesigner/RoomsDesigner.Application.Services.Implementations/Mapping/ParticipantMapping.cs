using AutoMapper;
using RoomsDesigner.Application.Models.Participant;
using RoomsDesigner.Domain.Entity;

namespace RoomsDesigner.Application.Services.Implementations.Mapping
{
    public class ParticipantMapping : Profile
    {
        public ParticipantMapping()
        {

            CreateMap<Participant, ParticipantModel>()
                .ForMember(dest => dest.CaseId, opt => opt.MapFrom(src => src.Room.Id));
        }
    }
}
