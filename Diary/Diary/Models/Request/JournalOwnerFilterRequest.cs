using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class JournalOwnerFilterRequest
    {
        [Required]
        public Guid Id { get; init; }
        [Required]
        public required string Name { get; init; }
        [Required]
        public required string Email { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
