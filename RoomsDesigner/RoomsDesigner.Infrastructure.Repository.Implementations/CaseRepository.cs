using RoomsDesigner.Domain.Entity;
using RoomsDesigner.Domain.Repository.Abstractions;
using RoomsDesigner.Infrastructure.EntityFramework;
using RoomsDesigner.Infrastructure.Repository.Implementations.EntityFramework;

namespace RoomsDesigner.Infrastructure.Repository.Implementations
{
    public class CaseRepository(ApplicationDbContext context) : EFRepository<Case, Guid>(context), ICaseRepository
    {
    }
}
