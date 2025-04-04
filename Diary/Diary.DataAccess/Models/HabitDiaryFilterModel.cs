using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess.Models
{
    public class HabitDiaryFilterModel
    {
        public string Description { get; init; }
        [Required]
        public Guid RoomId { get; init; }
        [Required]
        public Guid DiaryOwnerId { get; init; }
        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
