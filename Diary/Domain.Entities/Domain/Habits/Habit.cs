using Diary.Core.Domain.BaseTypes;
using Diary.Core.Domain.Diary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Core.Domain.Habits
{
    public class Habit : BaseEntity
    {
        public Guid DiaryId { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public List<HabitState> HabitStates { get; set; }
        public HabitDiary Diary { get; set; }
        public Habit()
        {
            HabitStates = new List<HabitState>();
        }
    }
}
