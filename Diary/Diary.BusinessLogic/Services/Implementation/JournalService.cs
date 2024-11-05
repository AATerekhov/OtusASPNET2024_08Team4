using AutoMapper;
using Diary.BusinessLogic.Models.DiaryOwner;
using Diary.BusinessLogic.Models.UserJournal;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.UserJournals;
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
    public class JournalService : BaseService, IJournalService
    {
        private readonly IMapper _mapper;
        private readonly IJournaRepository _JournalRepository;

        public JournalService(
           IMapper mapper,
           IJournaRepository journalRepository)
        {
            _mapper = mapper;
            _JournalRepository = journalRepository;
        }

        public async Task<Journal> CreateAsync(CreateOrEditJournalDto createOrEditJournalDto, CancellationToken cancellationToken)
        {
            var userJournal        = _mapper.Map<CreateOrEditJournalDto, Journal>(createOrEditJournalDto);
            var createdUserJournal = await _JournalRepository.AddAsync(userJournal, cancellationToken);

            await _JournalRepository.SaveChangesAsync(cancellationToken);

            return createdUserJournal;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var userJournal = await _JournalRepository.GetByIdAsync(id, cancellationToken)
                     ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Journal)));


            _JournalRepository.Delete(userJournal);

            await _JournalRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Journal>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _JournalRepository.GetAllAsync(cancellationToken, true);
        }

        public async Task<Journal> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _JournalRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Journal)));
        }

        public async Task<ICollection<Journal>> GetPagedAsync(JournalFilterDto filterDto, CancellationToken cancellationToken)
        {
            return await _JournalRepository.GetPagedAsync(
                _mapper.Map<JournalFilterDto, JournalFilterModel>(filterDto),
                cancellationToken
            );
        }

        public async Task<Journal> UpdateAsync(Guid id, CreateOrEditJournalDto createOrEditJournalDto, CancellationToken cancellationToken)
        {
            var userJournal = await _JournalRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(Journal)));

            userJournal.Description    = createOrEditJournalDto.Description;
            userJournal.JournalOwnerId = createOrEditJournalDto.JournalOwnerId;
            userJournal.RoomId         = createOrEditJournalDto.RoomId;

            _JournalRepository.Update(userJournal);
            await _JournalRepository.SaveChangesAsync(cancellationToken);

            return userJournal;
        }
    }
}
