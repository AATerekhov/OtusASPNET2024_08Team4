using RoomsDesigner.Domain.Entity.Base;

namespace RoomsDesigner.Domain.Entity
{
    public class Case : Entity<Guid>
    {
        private readonly ICollection<Participant> _players = [];
        public IReadOnlyCollection<Participant> Players => [.. _players];
        public Guid OwnerId { get; }
        public string? Name { get; private set; }
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
    }
}
