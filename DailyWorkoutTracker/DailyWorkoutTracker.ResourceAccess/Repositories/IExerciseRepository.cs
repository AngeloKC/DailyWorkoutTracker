using DailyWorkoutTracker.ResourceAccess.Models;

namespace DailyWorkoutTracker.ResourceAccess.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAsync();
        Task<Exercise> GetByIdAsync(int id);
        Task<Exercise> GetByNameAsync(string name);
        Task<Exercise> CreateAsync(Exercise exercise);
        Task<Exercise> UpdateAsync(Exercise exercise);
        Task DeleteAsync(int id);
        Task Seed();
    }
}
