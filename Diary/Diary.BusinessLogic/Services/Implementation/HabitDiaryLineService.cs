using AutoMapper;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.HabitDiaryLine;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Administration;
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
    public class HabitDiaryLineService : BaseService, IHabitDiaryLineService
    {
        private readonly IMapper _mapper;
        private readonly IHabitDiaryLineRepository _diaryLineRepository;

        public HabitDiaryLineService(
         IMapper mapper,
         IHabitDiaryLineRepository diaryLineRepository)
        {
            _mapper              = mapper;
            _diaryLineRepository = diaryLineRepository;
        }

        public async Task<HabitDiaryLine> CreateAsync(CreateOrEditHabitDiaryLineDto createOrEditDiaryLineDto, CancellationToken cancellationToken)
        {
            var diaryLine = _mapper.Map<CreateOrEditHabitDiaryLineDto, HabitDiaryLine>(createOrEditDiaryLineDto);
            var createdDiaryLine = await _diaryLineRepository.AddAsync(diaryLine, cancellationToken);

            await _diaryLineRepository.SaveChangesAsync(cancellationToken);

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

        public async Task<HabitDiaryLine> UpdateAsync(Guid id, CreateOrEditHabitDiaryLineDto createOrEditDiaryLineDto, CancellationToken cancellationToken)
        {
            var diaryLine = await _diaryLineRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitDiaryLine)));

            diaryLine.EventDescription = !string.IsNullOrWhiteSpace(createOrEditDiaryLineDto.EventDescription) ? createOrEditDiaryLineDto.EventDescription : diaryLine.EventDescription;
            diaryLine.DiaryId          = createOrEditDiaryLineDto.DiaryId != Guid.Empty ? createOrEditDiaryLineDto.DiaryId : diaryLine.DiaryId;
            diaryLine.HabitId          = createOrEditDiaryLineDto.HabitId != Guid.Empty ? createOrEditDiaryLineDto.HabitId : diaryLine.HabitId;
            diaryLine.Status           = createOrEditDiaryLineDto.Status;
            diaryLine.Cost             += createOrEditDiaryLineDto.Cost;

            _diaryLineRepository.Update(diaryLine);
            await _diaryLineRepository.SaveChangesAsync(cancellationToken);

            return diaryLine;
        }
    }
}
