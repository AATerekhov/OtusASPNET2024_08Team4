using Diary.Core.Domain.Diary;
using Diary.Core.Domain.Habits;
using Diary.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Repositories
{
    public class HabitRepository(EfDbContext context) : BaseRepository<Habit>(context), IHabitRepository
    {
        public Task<List<Habit>> GetAllByDiaryIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return GetAll(x => x.DiaryId == id).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
