using BookOfHabitsMicroservice.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class CoinsConfiguration : IEntityTypeConfiguration<Coins>
    {
        public void Configure(EntityTypeBuilder<Coins> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description)
                    .HasMaxLength(250);
            builder.HasOne(x => x.Room)
                    .WithMany("_bags");
            builder.HasOne(x => x.Habit)
                    .WithMany()
                    .IsRequired();
            builder.Property(x => x.Options).IsRequired();
            builder.Property(x => x.CostOfWinning).IsRequired();
            builder.Property(x => x.Forfeit).IsRequired();
        }
    }
}
