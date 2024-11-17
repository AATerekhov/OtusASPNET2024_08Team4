using AutoMapper;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.Diary;
using Diary.Core.Exceptions;
using Diary.DataAccess.Abstractions;
using Diary.DataAccess.Models;
using Diary.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services.Implementation
{
    public class HabitDiaryService : BaseService, IHabitDiaryService
    {
        private readonly IMapper _mapper;
        private readonly IHabitDiaryRepository _diaryRepository;

        public HabitDiaryService(
           IMapper mapper,
           IHabitDiaryRepository diaryRepository)
        {
            _mapper = mapper;
            _diaryRepository = diaryRepository;
        }

        public async Task<HabitDiary> CreateAsync(CreateOrEditHabitDiaryDto createOrEditDiaryDto, CancellationToken cancellationToken)
        {
            var diary        = _mapper.Map<CreateOrEditHabitDiaryDto, HabitDiary>(createOrEditDiaryDto);
            var createdDiary = await _diaryRepository.AddAsync(diary, cancellationToken);

            await _diaryRepository.SaveChangesAsync(cancellationToken);

            return createdDiary;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var habitDiary = await _diaryRepository.GetByIdAsync(id, cancellationToken)
                     ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitDiary)));


            _diaryRepository.Delete(habitDiary);

            await _diaryRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<HabitDiary>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _diaryRepository.GetAllAsync(cancellationToken, true);
        }

        public async Task<HabitDiary> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _diaryRepository.GetByIdAsync(id, cancellationToken, nameof(HabitDiary.Lines))
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitDiary)));
        }

        public async Task<ICollection<HabitDiary>> GetPagedAsync(HabitDiaryFilterDto filterDto, CancellationToken cancellationToken)
        {
            return await _diaryRepository.GetPagedAsync(
                _mapper.Map<HabitDiaryFilterDto, HabitDiaryFilterModel>(filterDto),
                cancellationToken
            );
        }

        public async Task<HabitDiary> UpdateAsync(Guid id, CreateOrEditHabitDiaryDto createOrEditDiaryDto, CancellationToken cancellationToken)
        {
            var habitDiary = await _diaryRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Core.Domain.Diary.HabitDiary)));

            habitDiary.Description    = !string.IsNullOrWhiteSpace(createOrEditDiaryDto.Description) ? createOrEditDiaryDto.Description : habitDiary.Description;
            habitDiary.DiaryOwnerId   = createOrEditDiaryDto.DiaryOwnerId != Guid.Empty ? createOrEditDiaryDto.DiaryOwnerId : habitDiary.DiaryOwnerId;
            habitDiary.RoomId         = createOrEditDiaryDto.RoomId != Guid.Empty ? createOrEditDiaryDto.RoomId : habitDiary.RoomId;

            _diaryRepository.Update(habitDiary);
            await _diaryRepository.SaveChangesAsync(cancellationToken);

            return habitDiary;
        }
    }
}
