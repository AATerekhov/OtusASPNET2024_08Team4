using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Configurations
{
    public class TemplateValuesConfiguration : IEntityTypeConfiguration<TemplateValues>
    {
        public void Configure(EntityTypeBuilder<TemplateValues> builder)
        {
            throw new NotImplementedException();
        }
    }
}
