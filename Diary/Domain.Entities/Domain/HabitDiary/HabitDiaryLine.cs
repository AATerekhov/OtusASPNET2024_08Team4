using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Core.Domain.BaseTypes;

namespace Diary.Core.Domain.Diary
{
    public class HabitDiaryLine : BaseEntity
    {
        public Guid DiaryId { get; set; }
        public Guid HabitId { get; set; }
        public required string EventDescription { get; set; }
        public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } 
        public Status Status { get; set; }
        public required HabitDiary Diary { get; set; }
    }
}
