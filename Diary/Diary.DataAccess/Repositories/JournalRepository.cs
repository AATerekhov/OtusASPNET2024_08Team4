using Diary.Core.Domain.Administration;
using Diary.Core.Domain.UserJournals;
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
    public class JournalRepository(EfDbContext context) : BaseRepository<Journal>(context), IJournaRepository
    {
        public Task<List<Journal>> GetPagedAsync(JournalFilterModel filterModel, CancellationToken cancellationToken)
        {
            var query = GetAll();

            query = query.Where(j => j.Id == filterModel.Id);

            query = query.Where(j => j.RoomId == filterModel.RoomId);

            query = query.Where(j => j.JournalOwnerId == filterModel.JournalOwnerId);

            query = query.Where(j => j.Description == filterModel.Description);

            query = query
                .Skip((filterModel.Page - 1) * filterModel.ItemsPerPage)
                .Take(filterModel.ItemsPerPage);

            return query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
