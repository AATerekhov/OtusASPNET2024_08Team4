using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class CreateOrEditHabitDiaryOwnerRequest
    {
        [Required]
        public required string Name { get; init; }
    }
}
