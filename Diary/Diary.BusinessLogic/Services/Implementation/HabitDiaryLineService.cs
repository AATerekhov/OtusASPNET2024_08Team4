using AutoMapper;
using Diary.BusinessLogic.Helpers;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.HabitDiaryLine;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.BaseTypes;
using Diary.Core.Domain.Diary;
using Diary.Core.Exceptions;
using Diary.DataAccess.Abstractions;
using Diary.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services.Implementation
{
    public class HabitDiaryLineService(IMapper _mapper, IHabitDiaryLineRepository _diaryLineRepository,
                                      IHabitDiaryRepository _diaryRepository) : BaseService, IHabitDiaryLineService
    {    
        public async Task<HabitDiaryLine> CreateAsync(CreateHabitDiaryLineDto createOrEditDiaryLineDto, CancellationToken cancellationToken)
        {
            var diaryLine = _mapper.Map<CreateHabitDiaryLineDto, HabitDiaryLine>(createOrEditDiaryLineDto);
            var createdDiaryLine = await _diaryLineRepository.AddAsync(diaryLine, cancellationToken);

            var diary = await _diaryRepository.GetByIdAsync(createdDiaryLine.DiaryId, cancellationToken)
                        ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(createdDiaryLine.DiaryId, nameof(HabitDiary)));

            diary.TotalCost += createdDiaryLine.Cost;

            await _diaryLineRepository.SaveChangesAsync(cancellationToken);

            _diaryRepository.Update(diary);

            await _diaryRepository.SaveChangesAsync(cancellationToken);

            return createdDiaryLine;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var diaryLine = await _diaryLineRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitDiaryLine)));


            _diaryLineRepository.Delete(diaryLine);

            await _diaryLineRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<HabitDiaryLine>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _diaryLineRepository.GetAllAsync(cancellationToken, true);
        }

        public async Task<ICollection<HabitDiaryLine>> GetAllByDiaryIdAsync(Guid id, CancellationToken cancellationToken)
        {
           return await _diaryLineRepository.GetAllByDiaryIdAsync(id, cancellationToken);
        }

        public async Task<HabitDiaryLine> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _diaryLineRepository.GetByIdAsync(id, cancellationToken)
                  ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitDiaryLine)));
        }

        public async Task<ICollection<HabitDiaryLine>> GetPagedAsync(HabitDiaryLineFilterDto filterDto, CancellationToken cancellationToken)
        {
            return await _diaryLineRepository.GetPagedAsync(
                         _mapper.Map<HabitDiaryLineFilterDto, HabitDiaryLineFilterModel>(filterDto),
                         cancellationToken
                     );
        }

        public async Task<HabitDiaryLine> UpdateAsync(Guid id, EditHabitDiaryLineDto editDiaryLineDto, CancellationToken cancellationToken)
        {
            var diaryLine = await _diaryLineRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitDiaryLine)));

            diaryLine.EventDescription = !string.IsNullOrWhiteSpace(editDiaryLineDto.EventDescription) ? editDiaryLineDto.EventDescription : diaryLine.EventDescription;    
            diaryLine.Status           = editDiaryLineDto.Status;
            diaryLine.ModifiedDate     = DateTimeHelper.ToDateTime(editDiaryLineDto.ModifiedDate, DateTimeHelper.DateFormat).ToUniversalTime();
        
            _diaryLineRepository.Update(diaryLine);
            await _diaryLineRepository.SaveChangesAsync(cancellationToken);

            return diaryLine;
        }
    }
}
