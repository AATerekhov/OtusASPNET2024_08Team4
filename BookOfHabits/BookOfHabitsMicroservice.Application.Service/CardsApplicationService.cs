using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Card;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Implementations.Base;
using BookOfHabitsMicroservice.Application.Services.Implementations.Default_values;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Domain.ValueObjects;

namespace BookOfHabitsMicroservice.Application.Services.Implementations
{
    public class CardsApplicationService(IRepository<Card, Guid> cardRepository,
                                         IRepository<TemplateValues, Guid> templateValuesRepository,
                                         IMapper mapper) : BaseService, ICardsApplicationService
    {
        public async Task<CardModel?> AddCardAsync(CreateCardModel cardInfo, CancellationToken token = default)
        {
            var card = new Card(name: new CardName(cardInfo.Name),
                                options: cardInfo.Options,
                                titles: DefaultValues.GetDefaultTemplateValues(),
                                description: cardInfo.Description);
            if (cardInfo.Image is not null)
                card.SetImage(cardInfo.Image);
            card.SetTitlesCheck(cardInfo.TitleCheckElements);
            card = await cardRepository.AddAsync(card, token)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(card.Id, nameof(Card)));
            return mapper.Map<CardModel>(card);
        }

        public async Task DeleteCard(Guid id, CancellationToken token = default)
        {
            var card = await cardRepository.GetByIdAsync(x => x.Id.Equals(id), includes:$"{nameof(Card.TemplateValues)}",cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Card)));
            var templateValues = card.TemplateValues;
            if (await cardRepository.DeleteAsync(entity: card, cancellationToken: token) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Card)));
            await templateValuesRepository.DeleteAsync(entity: templateValues, cancellationToken: token) ;
        }

        public async Task<IEnumerable<CardModel>> GetAllCardsAsync(CancellationToken token = default)
        {
            var cards = (await cardRepository.GetAllAsync(filter: x => x.IsPublic,
                                                          asNoTracking: true, 
                                                          cancellationToken: token));
            return cards.Select(mapper.Map<CardModel>);
        }

        public async Task<CardModel?> GetCardByIdAsync(Guid id, CancellationToken token = default)
        {
            Card card = await cardRepository.GetByIdAsync(x => x.Id.Equals(id),
                                                                includes: $"{nameof(Card.TemplateValues)}",
                                                                asNoTracking: true,
                                                                cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Card)));
            return mapper.Map<CardModel>(card);
        }

        public async Task UpdateCard(UpdateCardModel cardInfo, CancellationToken token = default)
        {
            var card = await cardRepository.GetByIdAsync(x => x.Id.Equals(cardInfo.Id), cancellationToken: token)
                 ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(cardInfo.Id, nameof(Card)));
            
            card.SetName(cardInfo.Name);            
            card.SetDescription(cardInfo.Description);
            card.SetTitlesCheck(cardInfo.TitleCheckElements);
            card.SetOptions(cardInfo.Options);
            if (cardInfo.Image is not null)
                card.SetImage(cardInfo.Image);
            
            await cardRepository.UpdateAsync(entity: card, token);
        }

        public async Task UpdateTemplateValues(Guid cardId, UpdateTemplateValuesModel tempateValuesInfo, CancellationToken token = default)
        {
            var card = await cardRepository.GetByIdAsync(x => x.Id.Equals(cardId), includes: nameof(Card.TemplateValues), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(cardId, nameof(Card)));
            var template = await templateValuesRepository.GetByIdAsync(x => x.Id.Equals(card.TemplateValues.Id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(card.TemplateValues.Id, nameof(TemplateValues)));
           
            template.SetStatus(tempateValuesInfo.Status);           
            template.SetTitleValue(tempateValuesInfo.TitleValue);            
            template.SetTitleCheck(tempateValuesInfo.TitleCheck);            
            template.SetTitleReportField(tempateValuesInfo.TitleReportField);           
            template.SetTags(tempateValuesInfo.Tags);           
            template.SetTitlePositive(tempateValuesInfo.TitlePositive);            
            template.SetTitleNegative(tempateValuesInfo.TitleNegative);
            await templateValuesRepository.UpdateAsync(entity: template, token);
        }
    }
}
