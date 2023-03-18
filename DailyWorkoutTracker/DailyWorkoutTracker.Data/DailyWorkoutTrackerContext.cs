using DailyWorkoutTracker.API.Models;
using DailyWorkoutTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

public class ExerciseDbContext : DbContext
{
    public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options)
    : base(options)
    {
    }

    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<MuscleGroup> MuscleGroups { get; set; }
    public DbSet<Equipment> Equipment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>()
            .HasMany(e => e.MuscleGroups)
            .WithMany(mg => mg.Exercises)
            .UsingEntity<ExerciseMuscleGroup>(
                j => j.HasOne(emg => emg.MuscleGroup)
                      .WithMany(mg => mg.ExerciseMuscleGroups)
                      .HasForeignKey(emg => emg.MuscleGroupId),
                j => j.HasOne(emg => emg.Exercise)
                      .WithMany(e => e.ExerciseMuscleGroups)
                      .HasForeignKey(emg => emg.ExerciseId),
                j =>
                {
                    j.HasKey(emg => new { emg.ExerciseId, emg.MuscleGroupId });
                    j.ToTable("ExerciseMuscleGroup");
                });

        modelBuilder.Entity<Exercise>()
            .HasMany(e => e.Equipment)
            .WithMany(eq => eq.Exercises)
            .UsingEntity<ExerciseEquipment>(
                j => j.HasOne(eeq => eeq.Equipment)
                      .WithMany(eq => eq.ExerciseEquipments)
                      .HasForeignKey(eeq => eeq.EquipmentId),
                j => j.HasOne(eeq => eeq.Exercise)
                      .WithMany(e => e.ExerciseEquipments)
                      .HasForeignKey(eeq => eeq.ExerciseId),
                j =>
                {
                    j.HasKey(eeq => new { eeq.ExerciseId, eeq.EquipmentId });
                    j.ToTable("ExerciseEquipment");
                });
    }
}
