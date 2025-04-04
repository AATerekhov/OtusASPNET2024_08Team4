using Diary.Core.Domain.BaseTypes;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class CreateHabitDiaryLineRequest
    {
        public Guid DiaryId { get; set; }
        public Guid EntityId { get; set; }
        public EntityType entityType { get; set; }
        public required string EventDescription { get; set; }
        public Status Status { get; set; }
        public required string ModifiedDate { get; set; }

        public decimal Cost { get; set; }
    }
}
