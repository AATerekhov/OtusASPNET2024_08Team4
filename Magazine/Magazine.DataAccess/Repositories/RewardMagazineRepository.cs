using Magazine.Core.Domain.Abstractions;
using Magazine.Core.Domain.Administration;
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
    public class RewardMagazineRepository(EfDbContext context) : BaseRepository<RewardMagazine>(context), IRewardMagazineRepository
    {
        public Task<List<RewardMagazine>> GetAllByMagazineOwnerIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return GetAll(x => x.MagazineOwnerId == id).ToListAsync(cancellationToken: cancellationToken);
        }

        public Task<List<RewardMagazine>> GetPagedAsync(RewardMagazineFilterModel filterModel, CancellationToken cancellationToken)
        {
            var query = GetAll();

            if (filterModel.RoomId != Guid.Empty)
            {
                query = query.Where(j => j.RoomId == filterModel.RoomId);
            }

            if (filterModel.MagazineOwnerId != Guid.Empty)
            {
                query = query.Where(j => j.MagazineOwnerId == filterModel.MagazineOwnerId);
            }

            if (!string.IsNullOrWhiteSpace(filterModel.Description))
            {
                query = query.Where(j => j.Description == filterModel.Description);
            }

            query = query
                .Skip((filterModel.Page - 1) * filterModel.ItemsPerPage)
                .Take(filterModel.ItemsPerPage);

            return query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
