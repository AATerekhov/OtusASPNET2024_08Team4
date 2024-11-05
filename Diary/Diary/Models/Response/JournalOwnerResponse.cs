using Diary.Core.Domain.UserJournals;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Response
{
    public class JournalOwnerResponse
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }

        public List<Journal> Journals { get; set; }
    }
}
