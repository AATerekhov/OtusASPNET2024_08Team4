using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Response
{
    public class HabitDiaryOwnerShortResponse
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
