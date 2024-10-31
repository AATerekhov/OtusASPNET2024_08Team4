using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class RepetitionConfiguration : IEntityTypeConfiguration<Repetition>
    {
        public void Configure(EntityTypeBuilder<Repetition> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Ignore(x => x.Habit);
        }
    }
}
