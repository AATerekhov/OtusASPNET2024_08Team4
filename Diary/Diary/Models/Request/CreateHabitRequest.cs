namespace Diary.Models.Request
{
    public class CreateHabitRequest
    {
        public Guid DiaryId { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
    }
}
