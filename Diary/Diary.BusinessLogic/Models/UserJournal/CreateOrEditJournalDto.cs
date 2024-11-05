using Diary.Core.Domain.UserJournals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Models.UserJournal
{
    public class CreateOrEditJournalDto
    {
        [Required]
        public Guid RoomId { get; init; }

        [Required]
        public string Description { get; init; }

        [Required]
        public Guid JournalOwnerId { get; init; }

    }
}
