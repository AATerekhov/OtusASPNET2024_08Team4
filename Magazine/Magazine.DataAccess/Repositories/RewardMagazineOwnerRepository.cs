using Magazine.Core.Domain.Abstractions;
using Magazine.Core.Domain.Administration;
using Magazine.DataAccess.Abstractions;
using Magazine.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.DataAccess.Repositories
{
    public class RewardMagazineOwnerRepository(EfDbContext context) : BaseRepository<RewardMagazineOwner>(context), IRewardMagazineOwnerRepository
    {
        public Task<List<RewardMagazineOwner>> GetPagedAsync(RewardMagazineOwnerFilterModel filterModel, CancellationToken cancellationToken)
        {
            var query = GetAll();

            if (!string.IsNullOrWhiteSpace(filterModel.Name))
            {
                query = query.Where(dO => dO.Name == filterModel.Name);
            }

            query = query
                .Skip((filterModel.Page - 1) * filterModel.ItemsPerPage)
                .Take(filterModel.ItemsPerPage);

            return query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
