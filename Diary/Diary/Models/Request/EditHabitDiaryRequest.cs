using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class EditHabitDiaryRequest
    {
        public string Description { get; init; }

        public decimal TotalCost { get; init; }
    }
}
