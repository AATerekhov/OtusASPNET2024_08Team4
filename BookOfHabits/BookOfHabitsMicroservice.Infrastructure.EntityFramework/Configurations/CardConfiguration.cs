using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                         .IsRequired()
                         .HasMaxLength(50)
                         .HasConversion(name => name.Name, name => new CardName(name));
            builder.HasOne(x => x.TemplateValues)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Options).IsRequired();
            builder.Property(x => x.Description)
                    .HasMaxLength(250);
            builder.Property(x => x.TitlesCheck)
                    .HasMaxLength(1500);
            builder.Property(x => x.Image)
                    .HasMaxLength(25000);
            builder.Ignore(x => x.TitleCheckElements);
        }
    }
}
