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
    public class HabitDiaryOwnerRepository(EfDbContext context) : BaseRepository<HabitDiaryOwner>(context), IHabitDiaryOwnerRepository
    {
        public Task<List<HabitDiaryOwner>> GetPagedAsync(HabitDiaryOwnerFilterModel filterModel, CancellationToken cancellationToken)
        {
            var query = GetAll();

            if (!string.IsNullOrWhiteSpace(filterModel.Name))
            { 
                query = query.Where(dO => dO.Name == filterModel.Name);
            }

            if (!string.IsNullOrWhiteSpace(filterModel.Email))
            {
                query = query.Where(dO => dO.Email == filterModel.Email);
            }        

            query = query
                .Skip((filterModel.Page - 1) * filterModel.ItemsPerPage)
                .Take(filterModel.ItemsPerPage);

            return query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
