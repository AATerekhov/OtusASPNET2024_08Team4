using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class DelayConfiguration : IEntityTypeConfiguration<Delay>
    {
        public void Configure(EntityTypeBuilder<Delay> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NameType).HasMaxLength(50);
        }
    }
}
