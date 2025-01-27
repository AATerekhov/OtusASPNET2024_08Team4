using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class CreateHabitDiaryRequest
    {
        public Guid RoomId { get; init; }

        public string Description { get; init; }

        public Guid DiaryOwnerId { get; init; }

        public decimal TotalCost { get; init; }
    }
}
