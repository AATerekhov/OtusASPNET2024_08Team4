using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Models.Habit
{
    public class CreateHabitDto
    {
        public Guid DiaryId { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
    }
}
