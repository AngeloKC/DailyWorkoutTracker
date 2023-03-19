namespace DailyWorkoutTracker.ResourceAccess.Models
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<ExerciseCategory>? ExerciseCategories { get; set; }
    }
}
