using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasConversion(name => name.Name, name => new RoomName(name));
            builder.HasOne(x => x.Manager).WithMany("_rooms");
            builder.Property(x => x.CreateDate).IsRequired();
            builder.HasMany("_habits").WithOne(nameof(Habit.Room));
            builder.Ignore(x => x.AssignedCoins);
            builder.Ignore(x => x.SuggestedHabits);
        }
    }
}
