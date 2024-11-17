using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.BaseTypes;

namespace Diary.Core.Domain.Diary
{
    public class HabitDiary : BaseEntity
    {
        public Guid RoomId { get; set; }

        public string Description { get; set; }

        public Guid DiaryOwnerId { get; set; }

        public List<HabitDiaryLine> Lines { get; set; }
        public required HabitDiaryOwner DiaryOwner { get; set; }

        public HabitDiary()
        {
            Lines = new List<HabitDiaryLine>();
        }
    }
}
