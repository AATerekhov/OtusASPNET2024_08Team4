using AutoMapper;
using Magazine.BusinessLogic.Models.RewardMagazine;
using Magazine.Core.Domain.Abstractions;
using Magazine.Core.Domain.Magazines;
using Magazine.Core.Exceptions;
using Magazine.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.BusinessLogic.Services.Implementatios
{
    public class RewardMagazineService : BaseService, IRewardMagazineService
    {
        private readonly IMapper _mapper;
        private readonly IRewardMagazineRepository _magazineRepository;

        public RewardMagazineService(
           IMapper mapper,
           IRewardMagazineRepository magazineRepository)
        {
            _mapper = mapper;
            _magazineRepository = magazineRepository;
        }

        public async Task<RewardMagazine> CreateAsync(CreateRewardMagazineDto createOrEditMagazineDto, CancellationToken cancellationToken)
        {
            var magazine        = _mapper.Map<CreateRewardMagazineDto, RewardMagazine>(createOrEditMagazineDto);
            var createdMagazine = await _magazineRepository.AddAsync(magazine, cancellationToken);

            await _magazineRepository.SaveChangesAsync(cancellationToken);

            return createdMagazine;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var magazine = await _magazineRepository.GetByIdAsync(id, cancellationToken)
                       ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(RewardMagazine)));


            _magazineRepository.Delete(magazine);

            await _magazineRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<RewardMagazine>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _magazineRepository.GetAllAsync(cancellationToken, true);
        }

        public async Task<List<RewardMagazine>> GetAllByMagazineOwnerIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _magazineRepository.GetAllByMagazineOwnerIdAsync(id, cancellationToken);
        }

        public async Task<RewardMagazine> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _magazineRepository.GetByIdAsync(id, cancellationToken, nameof(RewardMagazine.Lines))
                     ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(RewardMagazine)));
        }

        public async Task<ICollection<RewardMagazine>> GetPagedAsync(RewardMagazineFilterDto filterDto, CancellationToken cancellationToken)
        {
            return await _magazineRepository.GetPagedAsync(
               _mapper.Map<RewardMagazineFilterDto, RewardMagazineFilterModel>(filterDto),
               cancellationToken
           );
        }

        public async Task<RewardMagazine> UpdateAsync(Guid id, EditRewardMagazineDto editMagazineDto, CancellationToken cancellationToken)
        {
            var magazine = await _magazineRepository.GetByIdAsync(id, cancellationToken)
                     ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(RewardMagazine)));

            magazine.Description = !string.IsNullOrWhiteSpace(editMagazineDto.Description) ? editMagazineDto.Description : magazine.Description;
            magazine.TotalCost   = editMagazineDto.TotalCost;

            _magazineRepository.Update(magazine);
            await _magazineRepository.SaveChangesAsync(cancellationToken);

            return magazine;
        }
    }
}
