using Diary.Core.Domain.BaseTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Models
{
    public class HabitDiaryLineFilterModel
    {
        [Required]
        public Guid DiaryId { get; set; }
        [Required]
        public Guid HabitId { get; set; }
        public required string EventDescription { get; set; }
        public Status Status { get; set; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
