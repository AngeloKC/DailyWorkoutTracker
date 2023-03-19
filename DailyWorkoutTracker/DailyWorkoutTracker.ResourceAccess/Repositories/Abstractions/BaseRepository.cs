using Microsoft.EntityFrameworkCore;

namespace DailyWorkoutTracker.ResourceAccess.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly DailyWorkoutTrackerContext _context;

        public BaseRepository(DailyWorkoutTrackerContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var exercise = await _context.Set<T>().FindAsync(id);

            if (exercise != null)
            {
                _context.Set<T>().Remove(exercise);
            }
        }

        public virtual async Task<IList<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
