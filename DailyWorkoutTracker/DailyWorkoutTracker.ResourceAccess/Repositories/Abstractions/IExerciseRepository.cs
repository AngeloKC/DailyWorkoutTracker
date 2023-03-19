using DailyWorkoutTracker.ResourceAccess.Models;

namespace DailyWorkoutTracker.ResourceAccess.Repositories.Abstractions
{
    public interface IExerciseRepository : IBaseRepository<Exercise>
    {
        Task<Exercise> GetByNameAsync(string name);
        Task Seed();
    }
}
