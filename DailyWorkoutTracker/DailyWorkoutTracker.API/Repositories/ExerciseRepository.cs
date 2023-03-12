using DailyWorkoutTracker.API.Models;

namespace DailyWorkoutTracker.API.Repositories
{
    internal class ExerciseRepository : IExerciseRepository
    {
        private readonly DailyWorkoutTrackerContext _context;

        public ExerciseRepository(DailyWorkoutTrackerContext context)
        {
            _context = context;
        }

        public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
        {
            //await _context.Exercises.AddAsync(exercise);
            //await _context.SaveChangesAsync();
            //return exercise;
            return await Task.Run(() => new Exercise());
        }

        public async Task DeleteExerciseAsync(int id)
        {
            //var exercise = await _context.Exercises.FindAsync(id);
            //_context.Exercises.Remove(exercise);
            //await _context.SaveChangesAsync();


            await Task.Run(() => new Exercise());   
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            //return await _context.Exercises.ToListAsync();
            return await Task.Run(() => new List<Exercise>());
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            //return await _context.Exercises.FindAsync(id);
            return await Task.Run(() => new Exercise());
        }

        public async Task<Exercise> GetExerciseByNameAsync(string name)
        {
            //return await _context.Exercises.FirstOrDefaultAsync(e => e.Name == name);
            return await Task.Run(() => new Exercise());
        }

        public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
        {
            //_context.Exercises.Update(exercise);
            //await _context.SaveChangesAsync();
            //return exercise;
            return await Task.Run(() => new Exercise());
        }
    }
}
