using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoomsDesigner.Domain.Entity;

namespace RoomsDesigner.Infrastructure.EntityFramework.Configurations
{
    internal class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserMail)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(x => x.Name)
                    .HasMaxLength(50);
        }
    }
}
