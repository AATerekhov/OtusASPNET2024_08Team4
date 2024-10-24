using BookOfHabitsMicroservice.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class CoinsConfiguration : IEntityTypeConfiguration<Coins>
    {
        public void Configure(EntityTypeBuilder<Coins> builder)
        {
            throw new NotImplementedException();
        }
    }
}
