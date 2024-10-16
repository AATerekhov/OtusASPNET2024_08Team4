using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Core.Domain.Administration;
using Diary.Core.Domain.BaseTypes;

namespace Diary.Core.Domain.UserJournals
{
    public class UserJournal : BaseEntity
    {
        public Guid RoomId { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }

        public List<UserJournalLine> UserJournalLines { get; set; }
        public required User User { get; set; }

        public UserJournal()
        {
            UserJournalLines = new List<UserJournalLine>();
        }
    }
}
