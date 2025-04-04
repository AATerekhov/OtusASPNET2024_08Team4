using Diary.Core.Domain.Habits;

namespace Diary.Models.Response
{
    public class HabitStateResponse
    {
        public Guid Id { get; set; }
        public Guid HabitId { get; set; }
        public int Status { get; set; }
        public int Tag { get; set; }
        public int TitleValue { get; set; }
        public bool TitleCheck { get; set; }
        public int TextPositive { get; set; }
        public string? TitleReportField { get; set; }
        public int TextNegative { get; set; }
        public bool IsNotified { get; set; }
        public bool isRated { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
