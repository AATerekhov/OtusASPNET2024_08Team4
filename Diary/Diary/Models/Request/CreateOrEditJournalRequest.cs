using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class CreateOrEditJournalRequest
    {
        [Required]
        public Guid RoomId { get; init; }

        [Required]
        public string Description { get; init; }

        [Required]
        public Guid JournalOwnerId { get; init; }
    }
}
