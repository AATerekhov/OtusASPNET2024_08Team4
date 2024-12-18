using Diary.Core.Domain.BaseTypes;

namespace Diary.Models.Request
{
    public class EditHabitDiaryLineRequest
    {
        public required string EventDescription { get; set; }
        public Status Status { get; set; }
        public required string ModifiedDate { get; set; }
    }
}
