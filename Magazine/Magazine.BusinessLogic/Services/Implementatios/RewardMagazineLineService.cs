using AutoMapper;
using Magazine.BusinessLogic.Helpers;
using Magazine.BusinessLogic.Models.RewardMagazineLine;
using Magazine.Core.Domain.Abstractions;
using Magazine.Core.Domain.Magazines;
using Magazine.Core.Exceptions;
using Magazine.DataAccess.Abstractions;
using Magazine.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Services.Implementatios
{
    public class RewardMagazineLineService(IMapper _mapper, IRewardMagazineLineRepository _magazineLineRepository) : BaseService, IRewardMagazineLineService
    {     
        public async Task<RewardMagazineLine> CreateAsync(CreateRewardMagazineLineDto createOrEditMagazineLineDto, CancellationToken cancellationToken)
        {
            var magazineLine        = _mapper.Map<CreateRewardMagazineLineDto, RewardMagazineLine>(createOrEditMagazineLineDto);
            var createdMagazineLine = await _magazineLineRepository.AddAsync(magazineLine, cancellationToken);

            await _magazineLineRepository.SaveChangesAsync(cancellationToken);

            return createdMagazineLine;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var magazineLine = await _magazineLineRepository.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(RewardMagazineLine)));


            _magazineLineRepository.Delete(magazineLine);

            await _magazineLineRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<RewardMagazineLine>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _magazineLineRepository.GetAllAsync(cancellationToken, true);
        }

        public async Task<ICollection<RewardMagazineLine>> GetAllByMagazineIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _magazineLineRepository.GetAllByMagazineIdAsync(id, cancellationToken);
        }

        public async Task<RewardMagazineLine> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _magazineLineRepository.GetByIdAsync(id, cancellationToken)
                  ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(RewardMagazineLine)));
        }

        public async Task<ICollection<RewardMagazineLine>> GetPagedAsync(RewardMagazineLineFilterDto filterDto, CancellationToken cancellationToken)
        {
            return await _magazineLineRepository.GetPagedAsync(
                         _mapper.Map<RewardMagazineLineFilterDto, RewardMagazineLineFilterModel>(filterDto),
                         cancellationToken
                     );
        }

        public async Task<RewardMagazineLine> UpdateAsync(Guid id, EditRewardMagazineLineDto editMagazineLineDto, CancellationToken cancellationToken)
        {
            var magazineLine = await _magazineLineRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(RewardMagazineLine)));

            magazineLine.EventDescription = !string.IsNullOrWhiteSpace(editMagazineLineDto.EventDescription) ? editMagazineLineDto.EventDescription : magazineLine.EventDescription;        
            magazineLine.Cost = editMagazineLineDto.Cost;
            magazineLine.ModifiedDate = DateTimeHelper.ToDateTime(editMagazineLineDto.ModifiedDate, DateTimeHelper.DateFormat).ToUniversalTime();

            _magazineLineRepository.Update(magazineLine);
            await _magazineLineRepository.SaveChangesAsync(cancellationToken);

            return magazineLine;
        }
    }
}
