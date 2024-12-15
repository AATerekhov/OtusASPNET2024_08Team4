using RoomsDesigner.Domain.Entity.Base;

namespace RoomsDesigner.Domain.Entity
{
    public class Participant : Entity<Guid>
    {
        public string? UserMail { get; private set; }
        public string? Name { get; private set; }
        public Guid UserId { get; private set; }
        public Case Room { get;}
        public Participant(Guid id, string userMail, Case room) : base(id)
        {
            Room = room;
            UserMail = userMail;
        }

        public Participant(string userMail, Case room) : this(Guid.NewGuid(), userMail, room) 
        {
        
        }

        protected Participant() : base(Guid.NewGuid())
        {

        }
    }
}
