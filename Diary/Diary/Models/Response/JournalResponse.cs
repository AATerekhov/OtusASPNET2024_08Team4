using Diary.Core.Domain.Administration;
using Diary.Core.Domain.UserJournals;
using System.ComponentModel.DataAnnotations;

namespace Diary.Models.Response
{
    public class JournalResponse
    {

        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid RoomId { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public Guid JournalOwnerId { get; set; }

        public List<JournalLine> JournalLines { get; set; }   
    }
}
