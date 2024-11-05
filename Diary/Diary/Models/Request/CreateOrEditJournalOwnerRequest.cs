using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Request
{
    public class CreateOrEditJournalOwnerRequest
    {
        [Required]
        public required string Name { get; init; }
        [Required]
        public required string Email { get; init; }
    }
}
