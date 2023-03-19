using DailyWorkoutTracker.ResourceAccess.Models;
using DailyWorkoutTracker.ResourceAccess.Repositories.Abstractions;

namespace DailyWorkoutTracker.ResourceAccess.Repositories.Implementations
{
    public class MuscleGroupRepository : BaseRepository<MuscleGroup>, IMuscleGroupRepository
    {
        public MuscleGroupRepository(DailyWorkoutTrackerContext context) : base(context)
        {
        }
    }
}
