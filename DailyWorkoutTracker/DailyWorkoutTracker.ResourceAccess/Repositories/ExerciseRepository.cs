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

        public async Task<Exercise> CreateAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();

            return exercise;
        }

        public async Task DeleteAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Exercise>> GetAsync()
        {
            return await _context
                .Exercises
                .Include(e => e.ExerciseMuscleGroups)
                    .ThenInclude(emg => emg.MuscleGroup)
                .ToListAsync();
        }

        public async Task<Exercise> GetByIdAsync(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<Exercise> GetByNameAsync(string name)
        {
            return await _context.Exercises.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<Exercise> UpdateAsync(Exercise exercise)
        {
            _context.Exercises.Update(exercise);

            await _context.SaveChangesAsync();

            return exercise;
        }

        public async Task Seed()
        {
            try
            {
                if (!_context.Exercises.Any())
                {
                    await _context.Exercises.AddRangeAsync(GenerateExercises());
                    await _context.SaveChangesAsync();
                }

                if (!_context.MuscleGroups.Any())
                {
                    await _context.MuscleGroups.AddRangeAsync(GenerateMuscleGroups());
                    await _context.SaveChangesAsync();
                }

                if (!_context.Equipments.Any())
                {
                    await _context.Equipments.AddRangeAsync(GenerateEquipmentGroups());
                    await _context.SaveChangesAsync();
                }

                if (!_context.ExerciseMuscleGroups.Any())
                {
                    await _context.ExerciseMuscleGroups.AddRangeAsync(GenerateExerciseMuscleGroups());
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {

            }            
        }

        private List<MuscleGroup> GenerateMuscleGroups()
        {
            var muscleGroups = new List<MuscleGroup>
            {
                new MuscleGroup
                {
                    Name = "Heart",
                    Description = "Heart muscles"
                },
                new MuscleGroup
                {
                    Name = "Lungs",
                    Description = "Lungs"
                },
                new MuscleGroup
                {
                    Name = "Back",
                    Description = "Back muscles"
                },
                new MuscleGroup
                {
                    Name = "Chest",
                    Description = "Chest muscles"
                },
                new MuscleGroup
                {
                    Name = "Legs",
                    Description = "Leg muscles"
                },
                new MuscleGroup
                {
                    Name = "Arms",
                    Description = "Arm muscles"
                }
            };

            muscleGroups.ForEach(mg => mg.CreatedDate = DateTime.Now);
            muscleGroups.ForEach(mg => mg.CreatedBy = Environment.UserName);
            muscleGroups.ForEach(mg => mg.ModifiedDate = DateTime.Now);
            muscleGroups.ForEach(mg => mg.ModifiedBy = Environment.UserName);

            return muscleGroups;
        }

        private List<Equipment> GenerateEquipmentGroups() 
        {
            var equipments = new List<Equipment>
            {
                new Equipment
                {
                    Name = "Barbell",
                    Description = "Barbell"
                },
                new Equipment
                {
                    Name = "Dumbell",
                    Description = "Dumbell"
                },
                new Equipment
                {
                    Name = "Bodyweight",
                    Description = "Bodyweight"
                },
                new Equipment
                {
                    Name = "Treadmill",
                    Description = "Treadmill"
                },
                new Equipment
                {
                    Name = "Track",
                    Description = "Outdoor Track"
                }
            };

            equipments.ForEach(e => e.CreatedDate = DateTime.Now);
            equipments.ForEach(e => e.CreatedBy = Environment.UserName);
            equipments.ForEach(e => e.ModifiedDate = DateTime.Now);
            equipments.ForEach(e => e.ModifiedBy = Environment.UserName);

            return equipments;

        }

        private List<Exercise> GenerateExercises()
        {
            var exercises = new List<Exercise>
            {
                new Exercise
                {
                    Name = "Walk",
                    Description = "Walk around the block"
                },
                new Exercise
                {
                    Name = "Jog",
                    Description = "Jog around the block"
                },
                new Exercise
                {
                    Name = "Run",
                    Description = "Run around the block"
                },
                new Exercise
                {
                    Name = "Sprint",
                    Description = "Sprint around the block"
                },
                new Exercise
                {
                    Name = "Bench Press",
                    Description = "Lay on a bench and press a barbell up and down"                    
                },
                new Exercise
                {
                    Name = "Squat",
                    Description = "Stand up straight and squat down"
                },
                new Exercise
                {
                    Name = "Deadlift",
                    Description = "Stand up straight and lift a barbell off the ground"
                },
                new Exercise
                {
                    Name = "Bicep Curl",
                    Description = "Stand up straight and curl a barbell up and down"
                }
            };

            exercises.ForEach(e => e.CreatedDate = DateTime.Now);
            exercises.ForEach(e => e.CreatedBy = Environment.UserName);
            exercises.ForEach(e => e.ModifiedDate = DateTime.Now);
            exercises.ForEach(e => e.ModifiedBy = Environment.UserName);

            return exercises;
        }

        private List<ExerciseMuscleGroup> GenerateExerciseMuscleGroups() 
        {
            return new List<ExerciseMuscleGroup>
            {
                new ExerciseMuscleGroup
                {

                }
                // bench
                new ExerciseMuscleGroup
                {
                    ExerciseId = 1,
                    MuscleGroupId = 1
                },
                // squat
                new ExerciseMuscleGroup
                {
                    ExerciseId = 2,
                    MuscleGroupId = 2
                },
                // deadlift
                new ExerciseMuscleGroup
                {
                    ExerciseId = 3,
                    MuscleGroupId = 2
                },
                // bicep curl
                new ExerciseMuscleGroup
                {
                    ExerciseId = 4,
                    MuscleGroupId = 3
                }
            };
        }
    }
}
