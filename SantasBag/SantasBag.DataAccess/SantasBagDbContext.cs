using Microsoft.EntityFrameworkCore;
using SantasBug.DataAccess.Entities;

namespace SantasBug.DataAccess;

public class SantasBagDbContext : DbContext
{
    public SantasBagDbContext(DbContextOptions<SantasBagDbContext> options)
        :base(options)
    {
    }

    public DbSet<RewardEntity> Rewards { get; set; }
}
