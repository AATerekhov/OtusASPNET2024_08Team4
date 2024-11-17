using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Models
{
    public class HabitDiaryOwnerFilterModel
    {
        public required string Name { get; init; }
        public required string Email { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
