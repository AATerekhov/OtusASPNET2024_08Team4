using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.Core.Domain.BaseTypes;

namespace Diary.Core.Domain.UserJournals
{
    public class JournalLine : BaseEntity
    {
        public Guid JournalId { get; set; }
        public Guid RelatedEntityId { get; set; }
        public required string EventDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public EventType EventType { get; set; }
        public RelatedEntityType RelatedEntityType { get; set; }
        public required Journal Journal { get; set; }
    }
}
