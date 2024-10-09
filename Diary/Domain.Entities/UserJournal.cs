using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Administration;
using Domain.Entities.BaseTypes;

namespace Domain.Entities
{
    public class UserJournal : BaseEntity
    {
        public Guid RoomId { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }

        public List<UserJournalLine> UserJournalLines { get; set; }
        public User User { get; set; }
    }
}
