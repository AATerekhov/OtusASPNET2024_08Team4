using Diary.Core.Domain.Diary;
using Diary.DataAccess.Abstractions;
using Diary.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Repositories
{
    public class HabitDiaryLineRepository(EfDbContext context) : BaseRepository<HabitDiaryLine>(context), IHabitDiaryLineRepository
    {
        public Task<List<HabitDiaryLine>> GetAllByDiaryIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return GetAll(x => x.DiaryId == id).ToListAsync(cancellationToken: cancellationToken);
        }

        public Task<List<HabitDiaryLine>> GetPagedAsync(HabitDiaryLineFilterModel filterModel, CancellationToken cancellationToken)
        {
            var query = GetAll();

            if (!string.IsNullOrWhiteSpace(filterModel.EventDescription))
            {
               query = query.Where(dL => dL.EventDescription == filterModel.EventDescription);
            }

            query = query.Where(dL => dL.Status == filterModel.Status);

            if(filterModel.DiaryId != Guid.Empty)
            {
               query = query.Where(dL => dL.DiaryId == filterModel.DiaryId);
            }

            if (filterModel.EntityId != Guid.Empty)
            {
                query = query.Where(dL => dL.EntityId == filterModel.EntityId);
            }
          
            query = query
                .Skip((filterModel.Page - 1) * filterModel.ItemsPerPage)
                .Take(filterModel.ItemsPerPage);

            return query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
