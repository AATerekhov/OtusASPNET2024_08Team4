using Diary.Core.Domain.Diary;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Response
{
    public class HabitDiaryOwnerResponse
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public List<HabitDiaryResponse> Diaries { get; set; }
    }
}
