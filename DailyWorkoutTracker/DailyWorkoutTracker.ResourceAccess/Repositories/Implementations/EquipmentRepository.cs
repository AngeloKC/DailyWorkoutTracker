using DailyWorkoutTracker.ResourceAccess.Models;
using DailyWorkoutTracker.ResourceAccess.Repositories.Abstractions;

namespace DailyWorkoutTracker.ResourceAccess.Repositories.Implementations
{
    public class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRespository
    {
        public EquipmentRepository(DailyWorkoutTrackerContext context) : base(context)
        {
        }
    }
}
