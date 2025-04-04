using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Card;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;

namespace BookOfHabitsMicroservice.Application.Services.Implementations.Mapping
{
    public class CardMapping : Profile
    {
        public CardMapping()
        {
            CreateMap<Card, CardModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Name))
                .ForMember(dest => dest.TitleCheckElements, opt => opt.MapFrom(src => src.TitleCheckElements));

            CreateMap<TemplateValues, TemplateValuesModel>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
