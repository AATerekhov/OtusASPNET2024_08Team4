using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using Microsoft.EntityFrameworkCore;

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Coins> Вags { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Delay> DelayProperties { get; set; }
        public DbSet<Repetition> RepetitionProperties { get; set; }
        public DbSet<TimeResetInterval> TimeResetIntervalProperties { get; set; }
        public DbSet<TemplateValues> Signatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
