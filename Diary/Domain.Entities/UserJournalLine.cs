using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.BaseTypes;

namespace Domain.Entities
{
    public class UserJournalLine : BaseEntity
    {
        public Guid Id { get; set; } 
        public Guid UserJournalId { get; set; }
        public Guid RelatedEntityId { get; set; }
        public string EventDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public EventTypes EventTypes { get; set; }
        public RelatedEntityTypes RelatedEntityTypes { get; set; }
        public UserJournal UserJournal { get; set; } 
    }
}
