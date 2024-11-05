using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.BaseTypes;

namespace Diary.Core.Domain.UserJournals
{
    public class Journal : BaseEntity
    {
        public Guid RoomId { get; set; }

        public string Description { get; set; }

        public Guid JournalOwnerId { get; set; }

        public List<JournalLine> JournalLines { get; set; }
        public required JournalOwner JournalOwner { get; set; }

        public Journal()
        {
            JournalLines = new List<JournalLine>();
        }
    }
}
