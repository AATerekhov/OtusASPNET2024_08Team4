using BookOfHabitsMicroservice.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class HabitCardConfiguration : IEntityTypeConfiguration<HabitCard>
    {
        public void Configure(EntityTypeBuilder<HabitCard> builder)
        {
            throw new NotImplementedException();
        }
    }
}
