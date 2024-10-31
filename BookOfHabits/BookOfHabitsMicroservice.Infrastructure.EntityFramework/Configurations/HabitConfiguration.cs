using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class HabitConfiguration : IEntityTypeConfiguration<Habit>
    {
        public void Configure(EntityTypeBuilder<Habit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Owner).IsRequired();
            builder.Property(x => x.Room).IsRequired();
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasConversion(name => name.Name, name => new HabitName(name));
            builder.Property(x => x.Description)
                    .HasMaxLength(250);
            builder.Property(x => x.Options).IsRequired();
            builder.HasOne(x => x.Card)
                    .WithOne(x => x.Habit)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Room).WithMany("_habits");
            builder.HasOne(x => x.Owner).WithMany("_habits");
            builder.HasOne(x => x.Delay)
                    .WithOne(x => x.Habit)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.TimeResetInterval)
                    .WithOne(x => x.Habit)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Repetition)
                    .WithOne(x => x.Habit)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.Ignore(x => x.Coins);
        }
    }
}
