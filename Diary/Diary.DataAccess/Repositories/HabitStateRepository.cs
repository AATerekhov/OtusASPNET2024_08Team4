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
    public class HabitStateRepository(EfDbContext context) : BaseRepository<HabitState>(context), IHabitStateRepository
    {
        public Task<List<HabitState>> GetAllByHabitIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return GetAll(x => x.HabitId == id).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
