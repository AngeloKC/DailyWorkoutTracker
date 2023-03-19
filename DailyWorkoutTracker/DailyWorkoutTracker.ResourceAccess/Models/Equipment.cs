namespace DailyWorkoutTracker.ResourceAccess.Models
{
    public class Equipment : AuditableEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<ExerciseEquipment>? ExerciseEquipments { get; set; }
    }
}
