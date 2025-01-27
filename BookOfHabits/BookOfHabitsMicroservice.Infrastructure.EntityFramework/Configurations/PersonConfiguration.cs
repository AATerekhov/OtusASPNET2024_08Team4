using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasConversion(name => name.Name, name => new PersonName(name));
            builder.Ignore(x => x.SuggestedHabits);
            builder.Ignore(x => x.RoomManager);
        }
    }
}
