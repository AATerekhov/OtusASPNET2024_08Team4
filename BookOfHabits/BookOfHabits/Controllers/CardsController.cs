using AutoMapper;
using BookOfHabits.Requests.Card;
using BookOfHabits.Responses.Card;
using BookOfHabitsMicroservice.Application.Models.Card;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookOfHabits.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CardsController(ICardsApplicationService cardsApplicationService,
                                 IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CardShortResponse>> GetAllCards()
        {
            IEnumerable<CardModel> persons = await cardsApplicationService.GetAllCardsAsync(HttpContext.RequestAborted);
            return persons.Select(mapper.Map<CardShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<CardDetailedResponse> GetCardById(Guid id)
        {
            var card = await cardsApplicationService.GetCardByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<CardDetailedResponse>(card);
        }

        [HttpPost]
        public async Task<CardShortResponse> CreateCard(CreateCardRequest request)
        {
            var card = await cardsApplicationService.AddCardAsync(mapper.Map<CreateCardModel>(request), HttpContext.RequestAborted);
            return mapper.Map<CardShortResponse>(card);
        }

        [HttpPut]
        public async Task UpdateCardAsync(UpdateCardRequest request)
        {
            await cardsApplicationService.UpdateCard(mapper.Map<UpdateCardModel>(request), HttpContext.RequestAborted);
        }

        [HttpPut("{id:guid}")]
        public async Task UpdateTemplateValueAsync(Guid id, UpdateTemplateValuesRequest request)
        {
            await cardsApplicationService.UpdateTemplateValues(id, mapper.Map<UpdateTemplateValuesModel>(request), HttpContext.RequestAborted);
        }


        [HttpDelete("{id:guid}")]
        public async Task DeleteCard(Guid id)
        {
            await cardsApplicationService.DeleteCard(id, HttpContext.RequestAborted);
        }
    }
}
