using Diary.Core.Domain.BaseTypes;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Response
{
    public class HabitDiaryLineResponse
    {
        public Guid Id { get; set; }
        public Guid DiaryId { get; set; }
        public Guid EntityId { get; set; }
        public EntityType entityType { get; set; }
        public required string EventDescription { get; set; }
        public Status Status { get; set; }
        public DateTime ModifiedDate { get; set; }

        public decimal Cost { get; set; }
    }
}
