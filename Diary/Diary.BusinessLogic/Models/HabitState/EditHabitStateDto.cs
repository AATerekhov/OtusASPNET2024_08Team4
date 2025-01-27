using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Models.HabitState
{
    public class EditHabitStateDto
    {
        public int Status { get; set; }
        public int Tag { get; set; }
        public int TitleValue { get; set; }
        public bool TitleCheck { get; set; }
        public int TextPositive { get; set; }
        public string? TitleReportField { get; set; }
        public int TextNegative { get; set; }
        public bool IsNotified { get; set; }
        public bool isRated { get; set; }
        public required string ModifiedDate { get; set; }
    }
}
