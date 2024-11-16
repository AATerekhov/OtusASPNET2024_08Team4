using Microsoft.EntityFrameworkCore;
using RoomsDesigner.Core.Domain.Entities;
using RoomsDesigner.Core.Domain.Entities.Administration;
using RoomsDesigner.Core.Domain.Entities.IntermediateEntities;
using System;
using System.Collections.Generic;

namespace RoomsDesigner.DataAccess
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{ }

		public DbSet<Room> Rooms { get; set; }
		public DbSet<Diary> Diaries { get; set; }
		public DbSet<Habit> Habits { get; set; }
		public DbSet<HabitCategory> HabitCategories { get; set; }
		public DbSet<Reward> Rewards { get; set; }
		public DbSet<UserRoom> UserRooms { get; set; }
		public DbSet<RoomHabit> RoomHabits { get; set; }

		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			
			modelBuilder.Entity<Role>(entity =>
			{
				entity.HasKey(x => x.Id);
				entity.Property(x => x.Id).HasColumnName("RoleId");
				entity.Property(x => x.Name).HasMaxLength(32);
				entity.Property(x => x.Description).HasMaxLength(64);
			});

			modelBuilder.SharedTypeEntity<Dictionary<string, object>>("UserRole", builder =>
			{
				builder.Property<Guid>("UserId");
				builder.Property<int>("RoleId");
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasKey(x => x.Id);
				entity.Property(x => x.Id).HasColumnName("UserId");
				entity.Property(x => x.Name).HasMaxLength(32);
				entity.Property(x => x.Email).HasMaxLength(64);
				
				entity
					.HasMany(x => x.Roles)
					.WithMany(x => x.Users)
					.UsingEntity<Dictionary<string, object>>("UserRole",
						x => x.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
						x => x.HasOne<User>().WithMany().HasForeignKey("UserId"),
						j => j.HasKey("UserId", "RoleId"));
			});

			modelBuilder.Entity<UserRoom>(entity =>
			{
				entity.HasKey(x => new { x.UserId, x.RoomId });

				entity
					.HasOne(x => x.User)
					.WithMany(y => y.UserRooms)
					.HasForeignKey(ur => ur.UserId);

				entity
					.HasOne(x => x.Room)
					.WithMany(y => y.UserRooms)
					.HasForeignKey(ur => ur.RoomId);

				entity
					.HasOne(x => x.Diary)
					.WithMany()
					.HasForeignKey(y => y.DiaryId)
					.IsRequired(false);
			});

			modelBuilder.Entity<Room>(entity =>
			{
				entity.HasKey(x => x.Id);
				entity.Property(x => x.Id).HasColumnName("RoomId");
				entity.Property(x => x.Name).HasMaxLength(32);
				entity.Property(x => x.CreatedByUserId).IsRequired(true);
			});

			modelBuilder.Entity<RoomHabit>(entity =>
			{
				entity.HasKey(x => new { x.RoomId, x.HabitId });

				entity
					.HasOne(x => x.Room)
					.WithMany(y => y.RoomHabits)
					.HasForeignKey(rh => rh.RoomId);

				entity
					.HasOne(x => x.Habit)
					.WithMany(y => y.RoomHabits)
					.HasForeignKey(rh => rh.HabitId);

				entity.Property(x => x.SuggestedByUserId).IsRequired(false);
				entity.Property(x => x.IsApproved).IsRequired(false);
			});

			modelBuilder.Entity<HabitCategory>(entity =>
			{
				entity
					.HasMany(x => x.Habits)
					.WithOne(y => y.HabitCategory)
					.HasForeignKey(z => z.HabitCategoryId);

				entity.HasKey(x => x.Id);
				entity.Property(x => x.Id).HasColumnName("HabitCategoryId");
				entity.Property(x => x.Name).HasMaxLength(32);
				entity.Property(x => x.Description).HasMaxLength(256);
			});

			modelBuilder.Entity<Habit>(entity =>
			{
				entity.HasKey(x => x.Id);
				entity.Property(x => x.Id).HasColumnName("HabitId");
				entity.Property(x => x.Name).HasMaxLength(32);
			});
		}
	}
}
