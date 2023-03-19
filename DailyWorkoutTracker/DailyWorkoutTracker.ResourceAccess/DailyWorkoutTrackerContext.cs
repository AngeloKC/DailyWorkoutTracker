using DailyWorkoutTracker.ResourceAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyWorkoutTracker.ResourceAccess
{
    public class DailyWorkoutTrackerContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<ExerciseMuscleGroup> ExerciseMuscleGroups { get; set; }

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
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
