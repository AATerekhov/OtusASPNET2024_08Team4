using Diary.Core.Domain.BaseTypes;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class CreateHabitDiaryLineRequest
    {
        [Required]
        public Guid DiaryId { get; set; }
        [Required]
        public Guid EntityId { get; set; }
        [Required]
        public EntityType entityType { get; set; }
        [Required]
        public required string EventDescription { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public required string ModifiedDate { get; set; }

        public decimal Cost { get; set; }
    }
}
