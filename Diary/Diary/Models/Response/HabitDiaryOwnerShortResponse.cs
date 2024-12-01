using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Response
{
    public class HabitDiaryOwnerShortResponse
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
