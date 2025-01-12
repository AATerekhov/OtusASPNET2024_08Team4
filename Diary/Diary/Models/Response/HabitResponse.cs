using Diary.Core.Domain.Habits;

namespace Diary.Models.Response
{
    public class HabitResponse
    {
        public Guid Id { get; set; }
        public Guid DiaryId { get; set; }
        public string? Description { get; set; }

        public List<HabitStateResponse> HabitStates { get; set; }
    }
}
