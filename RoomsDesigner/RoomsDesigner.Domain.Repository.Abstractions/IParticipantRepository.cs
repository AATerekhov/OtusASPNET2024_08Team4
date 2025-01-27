using RoomsDesigner.Domain.Entity;
using System.Linq.Expressions;

namespace RoomsDesigner.Domain.Repository.Abstractions
{
    public interface IParticipantRepository : IRepository<Participant, Guid>
    {
        Task<Participant?> GetParticipantByIdAsync(Guid id, CancellationToken cancellationToken = default);        
    }
}
