using RoomsDesigner.Domain.Entity.Base;
using System.Xml.Linq;

namespace RoomsDesigner.Domain.Entity
{
    public class Participant : Entity<Guid>
    {
        public string UserMail { get; private set; }
        public string Name { get; private set; }
        public Guid UserId { get; private set; }
        public Case Room { get;}     

        public Participant(Guid id, string userMail, Case room, string name , Guid userId) : base(id)
        {
            Room = room;
            UserMail = userMail;
            Name = name;
            UserId = userId;
        }

        public Participant(string userMail, Case room, string name, Guid userId) : this(Guid.NewGuid(), userMail, room, name, userId) 
        {
        
        }

        protected Participant() : base(Guid.NewGuid())
        {

        }
        public void Update(Guid userId, string userMail, string name) 
        {
            UserId = userId;
            Name = name;
            UserMail = userMail;
        }
    }
}
