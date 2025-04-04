using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SantasBag.DataAccess.Entities;

namespace SantasBag.DataAccess.Configurations
{
    internal class RewardConfigurations : IEntityTypeConfiguration<RewardEntity>
    {
        public void Configure(EntityTypeBuilder<RewardEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Name)
                .IsRequired();
            builder.Property(b => b.Description)
                .IsRequired();
            builder.Property(b => b.Image)
                .IsRequired();
            builder.Property(b => b.Cost)
                .IsRequired();
            builder.Property(b => b.InstantBuy)
                .IsRequired();
            builder.Property(b => b.RoomId)
                .IsRequired();
        }
    }
}
