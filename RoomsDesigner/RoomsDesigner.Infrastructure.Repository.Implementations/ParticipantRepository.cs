using RoomsDesigner.Domain.Entity;
using RoomsDesigner.Domain.Repository.Abstractions;
using RoomsDesigner.Infrastructure.EntityFramework;
using RoomsDesigner.Infrastructure.Repository.Implementations.EntityFramework;

namespace RoomsDesigner.Infrastructure.Repository.Implementations
{
    public class ParticipantRepository(ApplicationDbContext context) : EFRepository<Participant, Guid>(context), IParticipantRepository
    {
        public async Task<Participant?> GetParticipantByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await base.GetByIdAsync(x => x.Id.Equals(id), $"{nameof(Participant.Room)}", true, cancellationToken);
    }
}
