using Microsoft.EntityFrameworkCore;
using SantasBag.DataAccess.Entities;

namespace SantasBag.DataAccess;

public class SantasBagDbContext : DbContext
{
    public SantasBagDbContext(DbContextOptions<SantasBagDbContext> options)
        :base(options)
    {
    }

    public DbSet<RewardEntity> Rewards { get; set; }
}
