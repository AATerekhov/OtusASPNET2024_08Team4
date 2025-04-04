using BookOfHabitsMicroservice.Application.Models.Card;
using BookOfHabitsMicroservice.Application.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions
{
    public interface ICardsApplicationService
    {
        Task<IEnumerable<CardModel>> GetAllCardsAsync(CancellationToken token = default);
        Task<CardModel?> GetCardByIdAsync(Guid id, CancellationToken token = default);
        Task<CardModel?> AddCardAsync(CreateCardModel cardInfo, CancellationToken token = default);
        Task<bool> UpdateCard(UpdateCardModel cardInfo, CancellationToken token = default);
        Task<bool> UpdateTemplateValues(Guid templateId, UpdateTemplateValuesModel tempateValuesInfo, CancellationToken token = default);
        Task<bool> DeleteCard(Guid id, CancellationToken token = default);
    }
}
