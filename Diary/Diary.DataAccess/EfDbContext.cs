using Diary.Core.Domain.Administration;
using Diary.Core.Domain.UserJournals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Diary.DataAccess
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
          
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserJournal> UserJournals { get; set; }
        public DbSet<UserJournalLine> UserJournalLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(u => u.UserJournals)
                      .WithOne(uj => uj.User)
                      .HasForeignKey(uj => uj.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(x => x.Id).HasColumnName("UserId");
                entity.Property(u => u.UserName).HasMaxLength(32);
                entity.Property(u => u.Email).HasMaxLength(32);
            });
       

            modelBuilder.Entity<UserJournal>(entity =>
            {
                entity.HasMany(uj => uj.UserJournalLines)
                .WithOne(ujl => ujl.UserJournal)
                .HasForeignKey(ujl => ujl.UserJournalId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(x => x.Id).HasColumnName("UserJournalId");
                entity.Property(u => u.Description).HasMaxLength(100);

            });

            modelBuilder.Entity<UserJournalLine>(entity =>
            {
                entity
                    .Property(ujl => ujl.EventTypes)
                    .HasConversion<int>(); 

                entity
                    .Property(ujl => ujl.RelatedEntityTypes)
                    .HasConversion<int>();

                entity.Property(x => x.Id).HasColumnName("UserJournalLineId");
                entity.Property(u => u.EventDescription).HasMaxLength(100);
            });
          
        }
    }
}
