using BroadcasterMicroservice.Domain.ValueObject;
using BroadcasterService.Domain.Entity.Base;

namespace BroadcasterMicroservice.Domain.Entity.Base
{
    public abstract class Addressee: Entity<Guid>
    {
        public string Name { get; private set; }
        protected Addressee(Guid id, string name):base(id)
        {
            Name = name;    
        }
        public virtual IEnumerable<NotificationMessage> Notify()
        { 
            return new List<NotificationMessage>();
        }
    }
}
