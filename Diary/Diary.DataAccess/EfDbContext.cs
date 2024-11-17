using Diary.Core.Domain.Administration;
using Diary.Core.Domain.Diary;
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

namespace Diary.DataAccess
{
    public class EfDbContext(DbContextOptions<EfDbContext> options) : DbContext(options)
    {    
        public DbSet<HabitDiaryOwner> DiaryOwners { get; set; }
        public DbSet<HabitDiary> Diaries { get; set; }
        public DbSet<HabitDiaryLine> DiaryLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<HabitDiaryOwner>(entity =>
            {
                entity.HasMany(dO => dO.Diaries)
                      .WithOne(d => d.DiaryOwner)
                      .HasForeignKey(dO => dO.DiaryOwnerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(dO => dO.Id).HasColumnName("DiaryOwnerId");
                entity.Property(dO => dO.Name).HasMaxLength(32);
                entity.Property(dO => dO.Email).HasMaxLength(32);
            });
       

            modelBuilder.Entity<HabitDiary>(entity =>
            {
                entity.HasMany(d => d.Lines)
                .WithOne(dL => dL.Diary)
                .HasForeignKey(dL => dL.DiaryId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(d => d.Id).HasColumnName("DiaryId");
                entity.Property(d => d.Description).HasMaxLength(100);

            });

            modelBuilder.Entity<HabitDiaryLine>(entity =>
            {
                entity
                    .Property(dL => dL.Status)
                    .HasConversion<int>();               

                entity.Property(dL => dL.Id).HasColumnName("DiaryLineId");
                entity.Property(dL => dL.EventDescription).HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
