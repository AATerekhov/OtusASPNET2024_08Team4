using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Response
{
    public class HabitShortResponse
    {
        public Guid Id { get; set; }
        public Guid DiaryId { get; set; }
        public string? Description { get; set; }
    }
}
