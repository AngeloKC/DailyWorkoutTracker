using DailyWorkoutTracker.ResourceAccess.Models;

namespace DailyWorkoutTracker.ResourceAccess.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(int id);
        Task<Exercise> GetExerciseByNameAsync(string name);
        Task<Exercise> CreateExerciseAsync(Exercise exercise);
        Task<Exercise> UpdateExerciseAsync(Exercise exercise);
        Task DeleteExerciseAsync(int id);
        Task SeedExercises();
    }
}
