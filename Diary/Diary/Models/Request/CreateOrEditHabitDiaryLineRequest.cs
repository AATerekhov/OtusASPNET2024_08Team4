using Diary.Core.Domain.BaseTypes;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class CreateOrEditHabitDiaryLineRequest
    {
        [Required]
        public Guid DiaryId { get; set; }
        [Required]
        public Guid HabitId { get; set; }
        [Required]
        public required string EventDescription { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public required string ModifiedDate { get; set; }
    }
}
