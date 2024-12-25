using RoomsDesigner.Domain.Entity.Base;

namespace RoomsDesigner.Domain.Entity
{
    public class Case : Entity<Guid>
    {
        private readonly ICollection<Participant> _players = [];
        public IReadOnlyCollection<Participant> Players => [.. _players];
        public Guid OwnerId { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; } = false;
        public Case(Guid id, string name, Guid ownerId) : base(id)
        {
            Name = name;
            OwnerId = ownerId;
        }

        public Case(string name, Guid ownerId) : this(Guid.NewGuid(), name, ownerId)
        {

        }
        protected Case() : base(Guid.NewGuid())
        {

        }
        public void Update(string name, Guid ownerId) 
        {
            Name = name;
            OwnerId = ownerId;
        }
        internal void Add(Participant participant) 
        {
            if (!_players.Contains(participant))
                _players.Add(participant);
        }
        public void Active() => IsActive = true;
        public void Close() => IsActive = false;
    }
}
