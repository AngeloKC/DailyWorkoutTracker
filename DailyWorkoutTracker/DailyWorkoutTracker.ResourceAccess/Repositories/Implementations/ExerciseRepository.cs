using DailyWorkoutTracker.ResourceAccess.Models;
using DailyWorkoutTracker.ResourceAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DailyWorkoutTracker.ResourceAccess.Repositories.Implementations
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(DailyWorkoutTrackerContext context) : base(context)
        { }

        public override async Task<IList<Exercise>> GetAsync()
        {
            return await _context
                .Exercises
                .Include(e => e.ExerciseMuscleGroups)
                    .ThenInclude(emg => emg.MuscleGroup)
                .ToListAsync();
        }

        public async Task<Exercise> GetByNameAsync(string name)
        {
            return await _context.Exercises.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task Seed()
        {
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

            if (!_context.Categories.Any())
            {
                await _context.Categories.AddRangeAsync(GenerateCategories());
                await _context.SaveChangesAsync();
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
                    Name = "Bicpes",
                    Description = "Arm muscles"
                },
                new MuscleGroup
                {
                    Name = "Triceps",
                    Description = "Arm muscles"
                }
            };

            muscleGroups.ForEach(mg => mg.CreatedDate = DateTime.Now);
            muscleGroups.ForEach(mg => mg.CreatedBy = Environment.UserName);
            muscleGroups.ForEach(mg => mg.ModifiedDate = null);
            muscleGroups.ForEach(mg => mg.ModifiedBy = null);

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
                    Name = "Bands",
                    Description = "Bands"
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
            equipments.ForEach(e => e.ModifiedDate = null);
            equipments.ForEach(e => e.ModifiedBy = null);

            return equipments;

        }

        private List<Category> GenerateCategories()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Cardio",
                    Description = "Cardio"
                },
                new Category
                {
                    Name = "Strength",
                    Description = "Strength"
                },
                new Category
                {
                    Name = "Flexibility",
                    Description = "Flexibility"
                },
                new Category
                {
                    Name = "Balance",
                    Description = "Balance"
                },
                new Category
                {
                    Name = "Endurance",
                    Description = "Endurance"
                }
            };

            categories.ForEach(c => c.CreatedDate = DateTime.Now);
            categories.ForEach(c => c.CreatedBy = Environment.UserName);
            categories.ForEach(c => c.ModifiedDate = null);
            categories.ForEach(c => c.ModifiedBy = null);

            return categories;
        }
    }
}
