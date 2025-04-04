using AutoMapper;
using BookOfHabits.Requests.Card;
using BookOfHabits.Responses.Card;
using BookOfHabitsMicroservice.Application.Models.Card;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
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
            IEnumerable<CardModel> cards = await cardsApplicationService.GetAllCardsAsync(HttpContext.RequestAborted);
            return cards.Select(mapper.Map<CardShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<CardDetailedResponse> GetCardById(Guid id)
        {
            var card = await cardsApplicationService.GetCardByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<CardDetailedResponse>(card);
        }

        [HttpPost]
        [Authorize]
        public async Task<CardShortResponse> CreateCard(CreateCardRequest request)
        {
            var card = await cardsApplicationService.AddCardAsync(mapper.Map<CreateCardModel>(request), HttpContext.RequestAborted);
            return mapper.Map<CardShortResponse>(card);
        }

        [HttpPut]
        [Authorize]
        public async Task<bool> UpdateCardAsync(UpdateCardRequest request)
        {
            return await cardsApplicationService.UpdateCard(mapper.Map<UpdateCardModel>(request), HttpContext.RequestAborted);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<bool> UpdateTemplateValueAsync(Guid id, UpdateTemplateValuesRequest request)
        {
           return await cardsApplicationService.UpdateTemplateValues(id, mapper.Map<UpdateTemplateValuesModel>(request), HttpContext.RequestAborted);
        }


        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<bool> DeleteCard(Guid id)
        {
           return await cardsApplicationService.DeleteCard(id, HttpContext.RequestAborted);
        }
    }
}
