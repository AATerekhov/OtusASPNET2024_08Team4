using AutoMapper;
using Diary.BusinessLogic.Helpers;
using Diary.BusinessLogic.Models.Habit;
using Diary.BusinessLogic.Models.HabitState;
using Diary.Core.Domain.Diary;
using Diary.Core.Domain.Habits;
using Diary.Core.Exceptions;
using Diary.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services.Implementation
{
    public class HabitStateService(IMapper                   _mapper, 
                                   IHabitStateRepository     _habitStateRepository,
                                   IHabitRepository          _habitRepository,
                                   IHabitDiaryRepository     _habitDiaryRepository,
                                   IHabitDiaryLineRepository _habitDiaryLineRepository) : BaseService, IHabitStateService
    {
        public async Task<HabitState> CreateAsync(CreateHabitStateDto createHabitStateDto, CancellationToken cancellationToken)
        {
            var habitState        = _mapper.Map<CreateHabitStateDto, HabitState>(createHabitStateDto);
            var createdHabitState = await _habitStateRepository.AddAsync(habitState, cancellationToken);

            await _habitStateRepository.SaveChangesAsync(cancellationToken);

            return createdHabitState;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var habitState = await _habitStateRepository.GetByIdAsync(id, cancellationToken)
                      ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitState)));


            _habitStateRepository.Delete(habitState);

            await _habitStateRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<HabitState>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _habitStateRepository.GetAllAsync(cancellationToken, true);
        }

        public async Task<ICollection<HabitState>> GetAllByHabitIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _habitStateRepository.GetAllByHabitIdAsync(id, cancellationToken);
        }

        public async Task<HabitState> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _habitStateRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<HabitState> UpdateAsync(Guid id, EditHabitStateDto editHabitStateDto, CancellationToken cancellationToken)
        {
            var habitState = await _habitStateRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Habit)));

            habitState.Status           = editHabitStateDto.Status;
            habitState.Tag              = editHabitStateDto.Tag;
            habitState.TitleValue       = editHabitStateDto.TitleValue;
            habitState.TitleCheck       = editHabitStateDto.TitleCheck;
            habitState.TitleReportField = !string.IsNullOrWhiteSpace(editHabitStateDto.TitleReportField) ? editHabitStateDto.TitleReportField : habitState.TitleReportField;
            habitState.TextNegative     = editHabitStateDto.TextNegative;
            habitState.IsNotified       = editHabitStateDto.IsNotified;
            habitState.isRated          = editHabitStateDto.isRated;
            habitState.ModifiedDate     = DateTimeHelper.ToDateTime(editHabitStateDto.ModifiedDate, DateTimeHelper.DateFormat).ToUniversalTime();


            _habitStateRepository.Update(habitState);
            await _habitStateRepository.SaveChangesAsync(cancellationToken);

            if(habitState.isRated)
            {
                var habit = await _habitRepository.GetByIdAsync(habitState.HabitId, cancellationToken);
                var diary = await _habitDiaryRepository.GetByIdAsync(habit.DiaryId, cancellationToken);

                var diaryLine = new HabitDiaryLine()
                {
                    DiaryId          = diary.Id,
                    EntityId         = habit.Id,
                    EventDescription = habit.Description,
                    ModifiedDate     = habitState.ModifiedDate,
                    Cost             = habit.Cost
                };

                await _habitDiaryLineRepository.AddAsync(diaryLine, cancellationToken);
                await _habitDiaryLineRepository.SaveChangesAsync(cancellationToken);
            }

            return habitState;
        }
    }
}
