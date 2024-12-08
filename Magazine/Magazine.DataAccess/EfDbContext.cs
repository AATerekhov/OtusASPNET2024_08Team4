using Magazine.Core.Domain.Administration;
using Magazine.Core.Domain.Magazines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.DataAccess
{
    public class EfDbContext(DbContextOptions<EfDbContext> options) : DbContext(options)
    {
        public DbSet<RewardMagazineOwner> MagazineOwners { get; set; }
        public DbSet<RewardMagazine> Magazines { get; set; }
        public DbSet<RewardMagazineLine> MagazineLine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RewardMagazineOwner>(entity =>
            {
                entity.HasMany(dO => dO.Magazines)
                      .WithOne(d => d.MagazineOwner)
                      .HasForeignKey(dO => dO.MagazineOwnerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(dO => dO.Id).HasColumnName("MagazineOwnerId");
                entity.Property(dO => dO.Name).HasMaxLength(32);
            });


            modelBuilder.Entity<RewardMagazine>(entity =>
            {
                entity.HasMany(d => d.Lines)
                .WithOne(dL => dL.Magazine)
                .HasForeignKey(dL => dL.MagazineId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(d => d.Id).HasColumnName("MagazineId");
                entity.Property(d => d.Description).HasMaxLength(100);

            });

            modelBuilder.Entity<RewardMagazineLine>(entity =>
            {
                entity.Property(dL => dL.Id).HasColumnName("MagazineLineId");
                entity.Property(dL => dL.EventDescription).HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
