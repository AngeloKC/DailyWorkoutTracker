using DailyWorkoutTracker.ResourceAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyWorkoutTracker.ResourceAccess
{
    public class DailyWorkoutTrackerContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseMuscleGroup> ExcerciseMuscleGroups { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        public string DbPath { get; }

        public DailyWorkoutTrackerContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
