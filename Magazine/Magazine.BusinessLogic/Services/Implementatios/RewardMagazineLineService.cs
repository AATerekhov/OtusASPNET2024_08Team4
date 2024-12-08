using AutoMapper;
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
    public class RewardMagazineLineService : BaseService, IRewardMagazineLineService
    {
        private readonly IMapper _mapper;
        private readonly IRewardMagazineLineRepository _magazineLineRepository;

        public RewardMagazineLineService(
           IMapper mapper,
           IRewardMagazineLineRepository magazineLineRepository)
        {
            _mapper = mapper;
            _magazineLineRepository = magazineLineRepository;
        }

        public async Task<RewardMagazineLine> CreateAsync(CreateOrEditRewardMagazineLineDto createOrEditMagazineLineDto, CancellationToken cancellationToken)
        {
            var magazineLine        = _mapper.Map<CreateOrEditRewardMagazineLineDto, RewardMagazineLine>(createOrEditMagazineLineDto);
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

        public async Task<RewardMagazineLine> UpdateAsync(Guid id, CreateOrEditRewardMagazineLineDto createOrEditMagazineLineDto, CancellationToken cancellationToken)
        {
            var magazineLine = await _magazineLineRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(RewardMagazineLine)));

            magazineLine.EventDescription = !string.IsNullOrWhiteSpace(createOrEditMagazineLineDto.EventDescription) ? createOrEditMagazineLineDto.EventDescription : magazineLine.EventDescription;
            magazineLine.MagazineId = createOrEditMagazineLineDto.MagazineId != Guid.Empty ? createOrEditMagazineLineDto.MagazineId : magazineLine.MagazineId;
            magazineLine.RewardId = createOrEditMagazineLineDto.RewardId != Guid.Empty ? createOrEditMagazineLineDto.RewardId : magazineLine.RewardId;
            magazineLine.Cost += createOrEditMagazineLineDto.Cost;

            _magazineLineRepository.Update(magazineLine);
            await _magazineLineRepository.SaveChangesAsync(cancellationToken);

            return magazineLine;
        }
    }
}
