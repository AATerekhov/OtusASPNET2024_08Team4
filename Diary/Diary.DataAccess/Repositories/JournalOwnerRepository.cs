using Diary.Core.Domain.Administration;
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
    public class JournalOwnerRepository(EfDbContext context) : BaseRepository<JournalOwner>(context), IJournalOwnerRepository
    {
        public Task<List<JournalOwner>> GetPagedAsync(JournalOwnerFilterModel filterModel, CancellationToken cancellationToken)
        {
            var query = GetAll();

            query = query.Where(d => d.Name == filterModel.Name);

            query = query.Where(d => d.Email == filterModel.Email);          

            query = query
                .Skip((filterModel.Page - 1) * filterModel.ItemsPerPage)
                .Take(filterModel.ItemsPerPage);

            return query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
