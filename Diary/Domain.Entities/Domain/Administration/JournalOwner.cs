using Diary.Core.Domain.BaseTypes;
using Diary.Core.Domain.UserJournals;

namespace Diary.Core.Domain.Administration
{
    public class JournalOwner : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }

        public List<Journal> Journals { get; set; }

        public JournalOwner()
        {
            Journals = new List<Journal>();
        }
    }
}
