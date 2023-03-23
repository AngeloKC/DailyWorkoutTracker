using DailyWorkoutTracker.ResourceAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyWorkoutTracker.ResourceAccess
{
    public class DailyWorkoutTrackerContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ExerciseMuscleGroup> ExerciseMuscleGroups { get; set; }
        public DbSet<ExerciseEquipment> ExerciseEquipments { get; set; }

        public string DbPath { get; }

        public DailyWorkoutTrackerContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "DailyWorkoutTracker.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseMuscleGroup>()
                .HasKey(emg => new { emg.ExerciseId, emg.MuscleGroupId });

            modelBuilder.Entity<ExerciseMuscleGroup>()
                .HasOne(emg => emg.Exercise)
                .WithMany(mg => mg.ExerciseMuscleGroups)
                .HasForeignKey(emg => emg.ExerciseId);

            modelBuilder.Entity<ExerciseMuscleGroup>()
                .HasOne(emg => emg.MuscleGroup)
                .WithMany(mg => mg.ExerciseMuscleGroups)
                .HasForeignKey(emg => emg.MuscleGroupId);

            modelBuilder.Entity<ExerciseCategory>()
                .HasKey(e => new { e.ExerciseId, e.CategoryId });

            modelBuilder.Entity<ExerciseCategory>()
                .HasOne(e => e.Exercise)
                .WithMany(ec => ec.ExerciseCategories)
                .HasForeignKey(e => e.ExerciseId);

            modelBuilder.Entity<ExerciseCategory>()
                .HasOne(c => c.Category)
                .WithMany(ec => ec.ExerciseCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<ExerciseEquipment>()
                .HasKey(e => new { e.ExerciseId, e.EquipmentId });

            modelBuilder.Entity<ExerciseEquipment>()
                .HasOne(e => e.Exercise)
                .WithMany(ec => ec.ExerciseEquipments)
                .HasForeignKey(e => e.ExerciseId);

            modelBuilder.Entity<ExerciseEquipment>()
                .HasOne(c => c.Equipment)
                .WithMany(ec => ec.ExerciseEquipments)
                .HasForeignKey(c => c.EquipmentId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
