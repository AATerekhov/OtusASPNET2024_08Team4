using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class HabitDiaryFilterRequest
    {
        public Guid Id { get; init; }
        public string Description { get; init; }
        public Guid RoomId { get; init; }

        public Guid DiaryOwnerId { get; init; }
        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
