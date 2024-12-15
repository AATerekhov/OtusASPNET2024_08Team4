using Diary.Core.Domain.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Models.HabitDiaryLine
{
    public class EditHabitDiaryLineDto
    {
        public required string EventDescription { get; set; }
        public Status Status { get; set; }
        public required string ModifiedDate { get; set; }
    }
}
