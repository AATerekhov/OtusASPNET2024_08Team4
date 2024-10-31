using AutoMapper;
using BookOfHabits.Requests.Card;
using BookOfHabits.Responses.Card;
using BookOfHabitsMicroservice.Application.Models.Card;

namespace BookOfHabits.Mapping
{
    public class CardMapping : Profile
    {
        public CardMapping()
        {
            CreateMap<CreateCardRequest, CreateCardModel>();
            CreateMap<UpdateCardRequest, CardModel>();
            CreateMap<CardModel, CardShortResponse>();
            CreateMap<CardModel, CardDetailedResponse>();
            CreateMap<UpdateTemplateValuesRequest, UpdateTemplateValuesModel>();
            CreateMap<TemplateValuesModel, TemplateValuesResponse>();
        }
    }
}
