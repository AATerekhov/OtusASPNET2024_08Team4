using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class JournalFilterRequest
    {
        [Required]
        public Guid Id { get; init; }
        [Required]
        public string Description { get; init; }
        [Required]
        public Guid RoomId { get; init; }

        [Required]
        public Guid JournalOwnerId { get; init; }
        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}
