using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class TemplateValuesConfiguration : IEntityTypeConfiguration<TemplateValues>
    {
        public void Configure(EntityTypeBuilder<TemplateValues> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NameType).HasMaxLength(50);
            builder.Property(x => x.TitleStatus).HasMaxLength(128);
            builder.Property(x => x.TitleValue).HasMaxLength(150);
            builder.Property(x => x.TitleCheck).HasMaxLength(100);
            builder.Property(x => x.TitleReportField).HasMaxLength(150);
            builder.Property(x => x.TitleTags).HasMaxLength(128);
            builder.Property(x => x.TitlePositive).HasMaxLength(100);
            builder.Property(x => x.TitleNegative).HasMaxLength(100);
            builder.Property(x => x.TitleFileReceiver).HasMaxLength(128);
        }
    }
}
