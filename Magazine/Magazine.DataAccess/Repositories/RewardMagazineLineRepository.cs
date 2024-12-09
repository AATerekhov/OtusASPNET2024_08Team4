using Magazine.Core.Domain.Magazines;
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
    public class RewardMagazineLineRepository(EfDbContext context) : BaseRepository<RewardMagazineLine>(context), IRewardMagazineLineRepository
    {
        public Task<List<RewardMagazineLine>> GetAllByMagazineIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return GetAll(x => x.MagazineId == id).ToListAsync(cancellationToken: cancellationToken);
        }

        public Task<List<RewardMagazineLine>> GetPagedAsync(RewardMagazineLineFilterModel filterModel, CancellationToken cancellationToken)
        {
            var query = GetAll();

            if (!string.IsNullOrWhiteSpace(filterModel.EventDescription))
            {
                query = query.Where(dL => dL.EventDescription == filterModel.EventDescription);
            }    

            if (filterModel.MagazineId != Guid.Empty)
            {
                query = query.Where(dL => dL.MagazineId == filterModel.MagazineId);
            }

            if (filterModel.RewardId != Guid.Empty)
            {
                query = query.Where(dL => dL.RewardId == filterModel.RewardId);
            }

            query = query
                .Skip((filterModel.Page - 1) * filterModel.ItemsPerPage)
                .Take(filterModel.ItemsPerPage);

            return query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
