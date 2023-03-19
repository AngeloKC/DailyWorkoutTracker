using DailyWorkoutTracker.ResourceAccess.Models;
using DailyWorkoutTracker.ResourceAccess.Repositories.Abstractions;

namespace DailyWorkoutTracker.ResourceAccess.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DailyWorkoutTrackerContext context) : base(context)
        {
        }
    }
}