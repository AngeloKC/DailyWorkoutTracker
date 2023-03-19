namespace DailyWorkoutTracker.ResourceAccess.Models
{
    public class Exercise : AuditableEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public virtual ICollection<ExerciseMuscleGroup>? ExerciseMuscleGroups { get; set; }
        public virtual ICollection<ExerciseEquipment>? ExerciseEquipments { get; set; }
        public virtual ICollection<ExerciseCategory>? ExerciseCategories { get; set; }
    }
}
