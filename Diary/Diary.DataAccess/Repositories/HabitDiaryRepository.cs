using Diary.Core.Domain.Administration;
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
    public class HabitDiaryRepository(EfDbContext context) : BaseRepository<HabitDiary>(context), IHabitDiaryRepository
    {
        public Task<List<HabitDiary>> GetPagedAsync(HabitDiaryFilterModel filterModel, CancellationToken cancellationToken)
        {
            var query = GetAll();

            if (filterModel.RoomId != Guid.Empty)
            { 
                query = query.Where(j => j.RoomId == filterModel.RoomId);
            }

            if (filterModel.DiaryOwnerId != Guid.Empty)
            {
                query = query.Where(j => j.DiaryOwnerId == filterModel.DiaryOwnerId);
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
