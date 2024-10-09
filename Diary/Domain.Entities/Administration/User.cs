using Domain.Entities.BaseTypes;

namespace Domain.Entities.Administration
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public List<UserJournal> UserJournals { get; set; }
    }
}
