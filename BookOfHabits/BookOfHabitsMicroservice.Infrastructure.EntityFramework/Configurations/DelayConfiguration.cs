using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class DelayConfiguration : IEntityTypeConfiguration<Delay>
    {
        public void Configure(EntityTypeBuilder<Delay> builder)
        {
            throw new NotImplementedException();
        }
    }
}
