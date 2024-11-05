using AutoMapper;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.JournalOwner;
using Diary.Core.Domain.Administration;
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
    public class JournalOwnerService : BaseService, IJournalOwnerService
    {
        private readonly IMapper _mapper;
        private readonly IJournalOwnerRepository _journalOwnerRepository;

        public JournalOwnerService(
           IMapper mapper,
           IJournalOwnerRepository journalOwnerRepositor)
        {
            _mapper = mapper;
            _journalOwnerRepository = journalOwnerRepositor;
        }


        public async Task<JournalOwner> CreateAsync(CreateOrEditJournalOwnerDto createOrEditJournalOwnerDto, CancellationToken cancellationToken)
        {
            var journalOwner = _mapper.Map<CreateOrEditJournalOwnerDto, JournalOwner>(createOrEditJournalOwnerDto);
            var createdJournalOwner = await _journalOwnerRepository.AddAsync(journalOwner, cancellationToken);

            await _journalOwnerRepository.SaveChangesAsync(cancellationToken);

            return createdJournalOwner;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var diaryOwner = await _journalOwnerRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(JournalOwner)));


            _journalOwnerRepository.Delete(diaryOwner);

            await _journalOwnerRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<JournalOwner>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _journalOwnerRepository.GetAllAsync(cancellationToken, true);
        }

        public async Task<JournalOwner> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _journalOwnerRepository.GetByIdAsync(id, cancellationToken)
                 ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(JournalOwner)));
        }

        public async Task<ICollection<JournalOwner>> GetPagedAsync(JournalOwnerFilterDto filterDto, CancellationToken cancellationToken)
        {
            return await _journalOwnerRepository.GetPagedAsync(
                  _mapper.Map<JournalOwnerFilterDto, JournalOwnerFilterModel>(filterDto),
                  cancellationToken
              );
        }

        public async Task<JournalOwner> UpdateAsync(Guid id, CreateOrEditJournalOwnerDto createOrEditJournalOwnerDto, CancellationToken cancellationToken)
        {
            var journalOwner = await _journalOwnerRepository.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(JournalOwner)));

            journalOwner.Name = createOrEditJournalOwnerDto.Name;
            journalOwner.Email = createOrEditJournalOwnerDto.Email;

            _journalOwnerRepository.Update(journalOwner);
            await _journalOwnerRepository.SaveChangesAsync(cancellationToken);

            return journalOwner;
        }
    }
}
