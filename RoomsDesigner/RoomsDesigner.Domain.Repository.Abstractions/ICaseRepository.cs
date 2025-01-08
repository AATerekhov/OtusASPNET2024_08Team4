using RoomsDesigner.Domain.Entity;
using System.Linq.Expressions;

namespace RoomsDesigner.Domain.Repository.Abstractions
{
    public interface ICaseRepository : IRepository<Case, Guid>
    {
        Task<Case?> GetCaseByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
