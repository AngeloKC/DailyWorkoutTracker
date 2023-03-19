namespace DailyWorkoutTracker.API.Representations
{
    public class Exercise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public MuscleGroup[]? MuscleGroups { get; set; }
        public Equipment[]? Equipment { get; set; }
        public Category[]? Category { get; set; }
    }
}
