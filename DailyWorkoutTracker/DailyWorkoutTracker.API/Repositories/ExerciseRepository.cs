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
            var exercises = new List<Exercise>
            {
                new Exercise
                {
                    Id = 1,
                    Name = "Bench Press",
                    Description = "Lay on a bench and press a barbell up and down",
                    MuscleGroups = new List<MuscleGroup>
                    {
                        new MuscleGroup
                        {
                            Id = 1,
                            Name = "Chest",
                            Description = "Chest muscles"
                        }
                    },
                    Equipment = new List<Equipment>
                    {
                        new Equipment
                        {
                            Id = 1,
                            Name = "Barbell",
                            Description = "Barbell"
                        }
                    }
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Squat",
                    Description = "Stand up straight and squat down",

                    MuscleGroups = new List<MuscleGroup>
                    {
                        new MuscleGroup
                        {
                            Id = 2,
                            Name = "Legs",
                            Description = "Leg muscles"
                        }
                    },
                    Equipment = new List<Equipment>
                    {
                        new Equipment
                        {
                            Id = 2,
                            Name = "Barbell",
                            Description = "Barbell"
                        }
                    }
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Deadlift",
                    Description = "Stand up straight and lift a barbell off the ground",                    
                    MuscleGroups = new List<MuscleGroup>
                    {
                        new MuscleGroup
                        {
                            Id = 2,
                            Name = "Legs",
                            Description = "Leg muscles"
                        }
                    },
                },
                new Exercise
                {
                    Id = 4,
                    Name = "Bicep Curl",
                    Description = "Stand up straight and curl a barbell up and down",
                    MuscleGroups = new List<MuscleGroup>
                    {
                        new MuscleGroup
                        {
                            Id = 3,
                            Name = "Arms",
                            Description = "Arm muscles"
                        }
                    },
                    Equipment = new List<Equipment>
                    {
                        new Equipment
                        {
                            Id = 1,
                            Name = "Barbell",
                            Description = "Barbell"
                        }
                    }                
                }
            };

            return await Task.Run(() => exercises);
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
