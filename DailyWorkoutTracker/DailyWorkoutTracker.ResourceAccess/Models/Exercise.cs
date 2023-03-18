namespace DailyWorkoutTracker.ResourceAccess.Models
{
    public class Exercise : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<MuscleGroup> MuscleGroups { get; set; }
        public List<Equipment> Equipment { get; set; }        
    }
}
