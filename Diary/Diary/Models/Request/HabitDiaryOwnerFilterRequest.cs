using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class HabitDiaryOwnerFilterRequest
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Email { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
