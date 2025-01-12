using AutoMapper;
using Diary.BusinessLogic.Models.Habit;
using Diary.BusinessLogic.Models.HabitDiary;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Diary;
using Diary.Core.Domain.Habits;
using Diary.Core.Exceptions;
using Diary.DataAccess.Abstractions;
using Diary.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services.Implementation
{
    public class HabitService(IMapper _mapper, IHabitRepository _habitRepository) : BaseService, IHabitService
    {
        public async Task<Habit> CreateAsync(CreateHabitDto createHabitDto, CancellationToken cancellationToken)
        {
            var habit = _mapper.Map<CreateHabitDto, Habit>(createHabitDto);
            var createdHabit = await _habitRepository.AddAsync(habit, cancellationToken);

            await _habitRepository.SaveChangesAsync(cancellationToken);

            return createdHabit;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var habit = await _habitRepository.GetByIdAsync(id, cancellationToken)
                      ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Habit)));


            _habitRepository.Delete(habit);

            await _habitRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Habit>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _habitRepository.GetAllAsync(cancellationToken, true);
        }

        public async Task<ICollection<Habit>> GetAllByDiaryIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _habitRepository.GetAllByDiaryIdAsync(id, cancellationToken);
        }

        public async Task<Habit> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _habitRepository.GetByIdAsync(id, cancellationToken, nameof(Habit.HabitStates))
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Habit)));
        }

        public async Task<Habit> UpdateAsync(Guid id, EditHabitDto editHabitDto, CancellationToken cancellationToken)
        {
            var habit = await _habitRepository.GetByIdAsync(id, cancellationToken)
                 ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Habit)));

            habit.Description = !string.IsNullOrWhiteSpace(editHabitDto.Description) ? editHabitDto.Description : habit.Description;

            _habitRepository.Update(habit);
            await _habitRepository.SaveChangesAsync(cancellationToken);

            return habit;
        }
    }
}
