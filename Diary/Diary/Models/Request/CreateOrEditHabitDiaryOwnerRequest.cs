using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class CreateOrEditHabitDiaryOwnerRequest
    {
        public required string Name { get; init; }
    }
}
