using Diary.Core.Domain.BaseTypes;
using Diary.Core.Domain.UserJournals;

namespace Diary.Core.Domain.Administration
{
    public class User : BaseEntity
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }

        public List<UserJournal> UserJournals { get; set; }

        public User()
        {
            UserJournals = new List<UserJournal>();
        }
    }
}
