using AutoMapper;
using BookOfHabitsMicroservice.Application.Models.Card;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using BookOfHabitsMicroservice.Application.Services.Abstractions.Exceptions;
using BookOfHabitsMicroservice.Application.Services.Implementations.Base;
using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
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
            var tempalteValues = new TemplateValues(status: "ToDo;Doing;Done",
                                                    titleValue: "Result",
                                                    titleCheck: "Tasks",
                                                    titleReportField: "Report",
                                                    tags: "Achievement;Important;Regular;Ordinary",
                                                    titlePositive: "Healthy",
                                                    titleNegative: "Damage");
            var card = new Card(name: new CardName(cardInfo.Name),
                                options: CardOptions.Status | CardOptions.Value,
                                titles: tempalteValues,
                                description: cardInfo.Description);

            if (cardInfo.Image is not null)
                card.SetImage(cardInfo.Image);
            if (cardInfo.TitleCheckElements is not null)
                card.SetTitlesCheck(cardInfo.TitleCheckElements);
            card = await cardRepository.AddAsync(card, token)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(card.Id, nameof(Card)));
            return mapper.Map<CardModel>(card);
        }

        public async Task DeleteCard(Guid id, CancellationToken token = default)
        {
            var card = await cardRepository.GetByIdAsync(x => x.Id.Equals(id))
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Card)));
            if (await cardRepository.DeleteAsync(card) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Card)));
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
            if (cardInfo.Name is not null)
                card.SetName(cardInfo.Name);
            if (cardInfo.Description is not null)
                card.SetDescription(cardInfo.Description);
            if (cardInfo.Image is not null)
                card.SetImage(cardInfo.Image);
            if (cardInfo.TitleCheckElements is not null)
                card.SetTitlesCheck(cardInfo.TitleCheckElements);
            card.SetOptions(cardInfo.Options);
            await cardRepository.UpdateAsync(entity: card, token);
        }

        public async Task UpdateTemplateValues(Guid cardId, UpdateTemplateValuesModel tempateValuesInfo, CancellationToken token = default)
        {
            var card = await cardRepository.GetByIdAsync(x => x.Id.Equals(cardId), includes: nameof(Card.TemplateValues), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(cardId, nameof(Card)));
            var template = await templateValuesRepository.GetByIdAsync(x => x.Id.Equals(card.TemplateValues.Id), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(card.TemplateValues.Id, nameof(TemplateValues)));
            if (tempateValuesInfo.Status is not null)
                template.SetStatus(tempateValuesInfo.Status);
            if (tempateValuesInfo.TitleValue is not null)
                template.SetTitleValue(tempateValuesInfo.TitleValue);
            if (tempateValuesInfo.TitleCheck is not null)
                template.SetTitleCheck(tempateValuesInfo.TitleCheck);
            if (tempateValuesInfo.TitleReportField is not null)
                template.SetTitleReportField(tempateValuesInfo.TitleReportField);
            if (tempateValuesInfo.Tags is not null)
                template.SetTags(tempateValuesInfo.Tags);
            if (tempateValuesInfo.TitlePositive is not null)
                template.SetTitlePositive(tempateValuesInfo.TitlePositive);
            if (tempateValuesInfo.TitleNegative is not null)
                template.SetTitleNegative(tempateValuesInfo.TitleNegative);
            await templateValuesRepository.UpdateAsync(entity: template, token);
        }
    }
}
