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
        /// <summary>
        /// Создать новую карточку.
        /// </summary>
        /// <param name="habitInfo">Модель создания Имя и Описание</param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task<CardModel?> AddCardAsync(CreateCardModel habitInfo, CancellationToken token = default)
        {
            var card = new Card(name: new CardName(habitInfo.Name),
                                options: Domain.Entity.Enums.CardOptions.Status | Domain.Entity.Enums.CardOptions.Value | Domain.Entity.Enums.CardOptions.Check,
                                titles: DefaultValues.GetDefaultTemplateValues(),
                                description: habitInfo.Description);            
            card.SetTitlesCheck(["Task 1", "Task 2"]);
            card.SetStatus(["ToDo", "Doing", "Done"]);
            card.SetTags(["Achievement", "Important", "Regular", "Ordinary"]);
            card = await cardRepository.AddAsync(card, token)
                ?? throw new BadRequestException(FormatBadRequestErrorMessage(card.Id, nameof(Card)));
            return mapper.Map<CardModel>(card);
        }

        /// <summary>
        /// Удаление карточки.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="BadRequestException"></exception>
        public async Task<bool> DeleteCard(Guid id, CancellationToken token = default)
        {
            var card = await cardRepository.GetByIdAsync(x => x.Id.Equals(id), includes: $"{nameof(Card.TemplateValues)}", cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Card)));
            var templateValues = card.TemplateValues;
            if (await cardRepository.DeleteAsync(entity: card, cancellationToken: token) is false)
                throw new BadRequestException(FormatBadRequestErrorMessage(id, nameof(Card)));
            return await templateValuesRepository.DeleteAsync(entity: templateValues, cancellationToken: token);
        }

        /// <summary>
        /// Получить список всех карточек.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CardModel>> GetAllCardsAsync(CancellationToken token = default)
        {
            var cards = (await cardRepository.GetAllAsync(filter: x => x.IsPublic,
                                                          asNoTracking: true,
                                                          cancellationToken: token));
            return cards.Select(mapper.Map<CardModel>);
        }

        /// <summary>
        /// Получение карточки по Identification.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<CardModel?> GetCardByIdAsync(Guid id, CancellationToken token = default)
        {
            Card card = await cardRepository.GetByIdAsync(x => x.Id.Equals(id),
                                                                includes: $"{nameof(Card.TemplateValues)}",
                                                                asNoTracking: true,
                                                                cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Card)));
            return mapper.Map<CardModel>(card);
        }

        /// <summary>
        /// Обновление основных свойств и options
        /// </summary>
        /// <param name="habitInfo">Модель обновления</param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<bool> UpdateCard(UpdateCardModel habitInfo, CancellationToken token = default)
        {
            var card = await cardRepository.GetByIdAsync(x => x.Id.Equals(habitInfo.Id), cancellationToken: token)
                 ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(habitInfo.Id, nameof(Card)));

            card.SetName(habitInfo.Name);
            card.SetDescription(habitInfo.Description);
            card.SetTitlesCheck(habitInfo.TitleCheckElements);
            card.SetStatus(habitInfo.Status);
            card.SetTags(habitInfo.Tags);
            card.SetOptions(habitInfo.Options);
            if (habitInfo.Image is not null)
                card.SetImage(habitInfo.Image);

            await cardRepository.UpdateAsync(entity: card, token);
            return true;
        }

        /// <summary>
        /// Обновление titul informations fields.
        /// </summary>
        /// <param name="templateId">Identifier template</param>
        /// <param name="tempateValuesInfo"></param>
        /// <param name="token"></param>
        /// <returns>true if Ok</returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<bool> UpdateTemplateValues(Guid templateId, UpdateTemplateValuesModel tempateValuesInfo, CancellationToken token = default)
        {
            var template = await templateValuesRepository.GetByIdAsync(x => x.Id.Equals(templateId), cancellationToken: token)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(templateId, nameof(TemplateValues)));

            template.SetTitleStatus(tempateValuesInfo.TitleStatus);
            template.SetTitleValue(tempateValuesInfo.TitleValue);
            template.SetTitleCheck(tempateValuesInfo.TitleCheck);
            template.SetTitleReportField(tempateValuesInfo.TitleReportField);
            template.SetTitleTags(tempateValuesInfo.TitleTags);
            template.SetTitlePositive(tempateValuesInfo.TitlePositive);
            template.SetTitleNegative(tempateValuesInfo.TitleNegative);
            template.SetTItleFileReceiver(tempateValuesInfo.TitleFileReceiver);
            await templateValuesRepository.UpdateAsync(entity: template, token);
            return true;
        }
    }
}
