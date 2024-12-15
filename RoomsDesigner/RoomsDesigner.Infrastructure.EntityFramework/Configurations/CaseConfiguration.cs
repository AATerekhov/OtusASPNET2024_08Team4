using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomsDesigner.Domain.Entity;

namespace RoomsDesigner.Infrastructure.EntityFramework.Configurations
{
    public class CaseConfiguration : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.HasMany("_players").WithOne(nameof(Participant.Room));
        }
    }
}
