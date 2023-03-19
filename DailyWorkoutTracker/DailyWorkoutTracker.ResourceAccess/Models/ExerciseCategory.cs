namespace DailyWorkoutTracker.ResourceAccess.Models
{
    public class ExerciseCategory : AuditableEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
