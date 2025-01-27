using Diary.Core.Domain.BaseTypes;
using Diary.Core.Domain.Diary;

namespace Diary.Core.Domain.Administration
{
    public class HabitDiaryOwner : BaseEntity
    {
        public required string Name { get; set; }
        public List<HabitDiary> Diaries { get; set; }

        public HabitDiaryOwner()
        {
            Diaries = new List<HabitDiary>();
        }
    }
}
