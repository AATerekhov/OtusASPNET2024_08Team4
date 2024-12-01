using AutoMapper;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.JournalOwner;
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
using System.Threading;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Services.Implementation
{
    public class HabitDiaryOwnerService : BaseService, IHabitDiaryOwnerService
    {
        private readonly IMapper _mapper;
        private readonly IHabitDiaryOwnerRepository _diaryOwnerRepository;

        public HabitDiaryOwnerService(
           IMapper mapper,
           IHabitDiaryOwnerRepository diaryOwnerRepository)
        {
            _mapper = mapper;
            _diaryOwnerRepository = diaryOwnerRepository;
        }


        public async Task<HabitDiaryOwner> CreateAsync(CreateOrEditHabitDiaryOwnerDto createOrEditDiaryOwnerDto, CancellationToken cancellationToken)
        {
            var diaryOwner = _mapper.Map<CreateOrEditHabitDiaryOwnerDto, HabitDiaryOwner>(createOrEditDiaryOwnerDto);
            var createdDiaryOwner = await _diaryOwnerRepository.AddAsync(diaryOwner, cancellationToken);

            await _diaryOwnerRepository.SaveChangesAsync(cancellationToken);

            return createdDiaryOwner;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var diaryOwner = await _diaryOwnerRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitDiaryOwner)));


            _diaryOwnerRepository.Delete(diaryOwner);

            await _diaryOwnerRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<HabitDiaryOwner>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _diaryOwnerRepository.GetAllAsync(cancellationToken, true);
        }

        public async Task<HabitDiaryOwner> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _diaryOwnerRepository.GetByIdAsync(id, cancellationToken, nameof(HabitDiaryOwner.Diaries))
                 ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitDiaryOwner)));
        }

        public async Task<ICollection<HabitDiaryOwner>> GetPagedAsync(HabitDiaryOwnerFilterDto filterDto, CancellationToken cancellationToken)
        {
            return await _diaryOwnerRepository.GetPagedAsync(
                  _mapper.Map<HabitDiaryOwnerFilterDto, HabitDiaryOwnerFilterModel>(filterDto),
                  cancellationToken
              );
        }

        public async Task<HabitDiaryOwner> UpdateAsync(Guid id, CreateOrEditHabitDiaryOwnerDto createOrEditDiaryOwnerDto, CancellationToken cancellationToken)
        {
            var diaryOwner = await _diaryOwnerRepository.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(HabitDiaryOwner)));

            diaryOwner.Name = createOrEditDiaryOwnerDto.Name;

            _diaryOwnerRepository.Update(diaryOwner);
            await _diaryOwnerRepository.SaveChangesAsync(cancellationToken);

            return diaryOwner;
        }
    }
}
