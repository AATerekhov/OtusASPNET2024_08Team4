using BroadcasterMicroservice.Domain.Entity.Exceptions;
using BroadcasterService.Domain.Entity.Base;

namespace BroadcasterMicroservice.Domain.Entity
{
    public class AddressGroup: Entity<Guid>
    {
        private readonly ICollection<DiaryAddressee> _participants = [];
        public IReadOnlyCollection<DiaryAddressee> Participants => [.. _participants];
        public string GroupName { get; }
        public bool IsActive { get; private set; } = true;
        public AddressGroup(Guid id, string name):base(id)
        {
            GroupName = name;
        }
        protected AddressGroup() : base(Guid.NewGuid()) 
        {
        
        }
        public void Сlose()=> IsActive = false;
        public void AddNotification(DiaryAddressee addressee)
        {
            if (_participants.Contains(addressee))
                throw new DoubleAddresseeException(addressee, this);
            _participants.Add(addressee);
        }
    }
}
