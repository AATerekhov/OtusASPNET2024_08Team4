using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Response
{
    public class HabitDiaryShortResponse
    {

        public Guid Id { get; set; }

        public Guid RoomId { get; set; }
        public string Description { get; set; }

        public Guid DiaryOwnerId { get; set; }

        public decimal TotalCost { get; set; }
    }
}
