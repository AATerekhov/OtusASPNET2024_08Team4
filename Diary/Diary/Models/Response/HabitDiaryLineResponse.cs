using Diary.Core.Domain.BaseTypes;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Response
{
    public class HabitDiaryLineResponse
    {
        [Required]
        public Guid Id { get; set; }
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
        public DateTime ModifiedDate { get; set; }

        public decimal Cost { get; set; }
    }
}
