using Diary.Core.Domain.Administration;
using Diary.Core.Domain.UserJournals;
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
      
        public DbSet<JournalOwner> Users { get; set; }
        public DbSet<Journal> UserJournals { get; set; }
        public DbSet<JournalLine> UserJournalLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<JournalOwner>(entity =>
            {
                entity.HasMany(u => u.Journals)
                      .WithOne(uj => uj.JournalOwner)
                      .HasForeignKey(uj => uj.JournalOwnerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(x => x.Id).HasColumnName("JournalOwnerId");
                entity.Property(u => u.Name).HasMaxLength(32);
                entity.Property(u => u.Email).HasMaxLength(32);
            });
       

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.HasMany(uj => uj.JournalLines)
                .WithOne(ujl => ujl.Journal)
                .HasForeignKey(ujl => ujl.JournalId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(x => x.Id).HasColumnName("JournalId");
                entity.Property(u => u.Description).HasMaxLength(100);

            });

            modelBuilder.Entity<JournalLine>(entity =>
            {
                entity
                    .Property(ujl => ujl.EventType)
                    .HasConversion<int>(); 

                entity
                    .Property(ujl => ujl.RelatedEntityType)
                    .HasConversion<int>();

                entity.Property(x => x.Id).HasColumnName("JournalLineId");
                entity.Property(u => u.EventDescription).HasMaxLength(100);
            });
          
        }
    }
}
