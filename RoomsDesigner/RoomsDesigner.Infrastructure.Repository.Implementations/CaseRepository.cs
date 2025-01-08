using RoomsDesigner.Domain.Entity;
using RoomsDesigner.Domain.Repository.Abstractions;
using RoomsDesigner.Infrastructure.EntityFramework;
using RoomsDesigner.Infrastructure.Repository.Implementations.EntityFramework;

namespace RoomsDesigner.Infrastructure.Repository.Implementations
{
    public class CaseRepository(ApplicationDbContext context) : EFRepository<Case, Guid>(context), ICaseRepository
    {
        public async Task<Case?> GetCaseByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await base.GetByIdAsync(filter: x => x.Id.Equals(id), includes: "_players", asNoTracking: true, token: cancellationToken);
    }
}
