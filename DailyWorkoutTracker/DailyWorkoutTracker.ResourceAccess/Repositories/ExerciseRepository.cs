using DailyWorkoutTracker.ResourceAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyWorkoutTracker.ResourceAccess.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly DailyWorkoutTrackerContext _context;

        public ExerciseRepository(DailyWorkoutTrackerContext context)
        {
            _context = context;
        }

        public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            
            return exercise;            
        }

        public async Task DeleteExerciseAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<Exercise> GetExerciseByNameAsync(string name)
        {
            return await _context.Exercises.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
        {
            _context.Exercises.Update(exercise);

            await _context.SaveChangesAsync();

            return exercise;
        }

        public async Task SeedExercises()
        {
            if (!_context.Exercises.Any())
            {
                var  exercises = GenerateExercises();

                await _context.Exercises.AddRangeAsync(exercises);
                await _context.SaveChangesAsync();
            }
        }

        private List<Exercise> GenerateExercises()
        {
            return new List<Exercise>
            {
                new Exercise
                {
                    Name = "Bench Press",
                    Description = "Lay on a bench and press a barbell up and down",
                    MuscleGroups = new List<MuscleGroup>
                    {
                        new MuscleGroup
                        {
                            Name = "Chest",
                            Description = "Chest muscles"
                        }
                    },
                    Equipment = new List<Equipment>
                    {
                        new Equipment
                        {
                            Name = "Barbell",
                            Description = "Barbell"
                        }
                    }
                },
                new Exercise
                {
                    Name = "Squat",
                    Description = "Stand up straight and squat down",

                    MuscleGroups = new List<MuscleGroup>
                    {
                        new MuscleGroup
                        {
                            Name = "Legs",
                            Description = "Leg muscles"
                        }
                    },
                    Equipment = new List<Equipment>
                    {
                        new Equipment
                        {
                            Name = "Barbell",
                            Description = "Barbell"
                        }
                    }
                },
                new Exercise
                {
                    Name = "Deadlift",
                    Description = "Stand up straight and lift a barbell off the ground",
                    MuscleGroups = new List<MuscleGroup>
                    {
                        new MuscleGroup
                        {
                            Name = "Legs",
                            Description = "Leg muscles"
                        }
                    },
                },
                new Exercise
                {
                    Name = "Bicep Curl",
                    Description = "Stand up straight and curl a barbell up and down",
                    MuscleGroups = new List<MuscleGroup>
                    {
                        new MuscleGroup
                        {
                            Name = "Arms",
                            Description = "Arm muscles"
                        }
                    },
                    Equipment = new List<Equipment>
                    {
                        new Equipment
                        {
                            Name = "Barbell",
                            Description = "Barbell"
                        }
                    }
                }
            };
        }
    }
}
