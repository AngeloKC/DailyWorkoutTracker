namespace DailyWorkoutTracker.ResourceAccess.Models
{
    public class ExerciseMuscleGroup : AuditableEntity
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int MuscleGroupId { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
    }
}
