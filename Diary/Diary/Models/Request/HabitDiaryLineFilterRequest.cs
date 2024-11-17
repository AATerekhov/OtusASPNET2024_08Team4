using Diary.Core.Domain.BaseTypes;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class HabitDiaryLineFilterRequest
    {
        public Guid DiaryId { get; set; }
        public Guid HabitId { get; set; }
        public required string EventDescription { get; set; }
        public Status Status { get; set; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
