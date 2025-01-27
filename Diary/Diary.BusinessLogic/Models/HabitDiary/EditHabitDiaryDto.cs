using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Models.HabitDiary
{
    public class EditHabitDiaryDto
    {
        public string Description { get; init; }

        public decimal TotalCost { get; init; }
    }
}
