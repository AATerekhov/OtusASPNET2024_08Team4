using AutoMapper;
using Magazine.BusinessLogic.Models.RewardMagazineOwner;
using Magazine.Core.Domain.Abstractions;
using Magazine.Core.Domain.Administration;
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
    public class RewardMagazineOwnerService : BaseService, IRewardMagazineOwnerService
    {
        private readonly IMapper _mapper;
        private readonly IRewardMagazineOwnerRepository _magazineOwnerRepository;

        public RewardMagazineOwnerService(
           IMapper mapper,
           IRewardMagazineOwnerRepository magazineOwnerRepository)
        {
            _mapper = mapper;
            _magazineOwnerRepository = magazineOwnerRepository;
        }

        public async Task<RewardMagazineOwner> CreateAsync(CreateOrEditRewardMagazineOwnerDto createOrEditMagazineOwnerDto, CancellationToken cancellationToken)
        {
            var magazineOwner = _mapper.Map<CreateOrEditRewardMagazineOwnerDto, RewardMagazineOwner>(createOrEditMagazineOwnerDto);
            var createdMagazineOwner = await _magazineOwnerRepository.AddAsync(magazineOwner, cancellationToken);

            await _magazineOwnerRepository.SaveChangesAsync(cancellationToken);

            return magazineOwner;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var magazineOwner = await _magazineOwnerRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(RewardMagazineOwner)));


            _magazineOwnerRepository.Delete(magazineOwner);

            await _magazineOwnerRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<RewardMagazineOwner>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _magazineOwnerRepository.GetAllAsync(cancellationToken, true);
        }

        public async Task<RewardMagazineOwner> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _magazineOwnerRepository.GetByIdAsync(id, cancellationToken, nameof(RewardMagazineOwner.Magazines))
                  ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(RewardMagazineOwner)));
        }

        public async Task<ICollection<RewardMagazineOwner>> GetPagedAsync(RewardMagazineOwnerFilterDto filterDto, CancellationToken cancellationToken)
        {
            return await _magazineOwnerRepository.GetPagedAsync(
                  _mapper.Map<RewardMagazineOwnerFilterDto, RewardMagazineOwnerFilterModel>(filterDto),
                  cancellationToken
              );
        }

        public async Task<RewardMagazineOwner> UpdateAsync(Guid id, CreateOrEditRewardMagazineOwnerDto createOrEditMagazineOwnerDto, CancellationToken cancellationToken)
        {
            var magazineOwner = await _magazineOwnerRepository.GetByIdAsync(id, cancellationToken)
                  ?? throw new NotFoundException(FormatFullNotFoundErrorMessage(id, nameof(RewardMagazineOwner)));

            magazineOwner.Name = createOrEditMagazineOwnerDto.Name;

            _magazineOwnerRepository.Update(magazineOwner);
            await _magazineOwnerRepository.SaveChangesAsync(cancellationToken);

            return magazineOwner;
        }
    }
}
