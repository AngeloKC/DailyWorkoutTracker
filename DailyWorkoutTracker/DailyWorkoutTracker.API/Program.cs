using DailyWorkoutTracker.ResourceAccess;
using DailyWorkoutTracker.ResourceAccess.Repositories.Abstractions;
using DailyWorkoutTracker.ResourceAccess.Repositories.Implementations;
using Category = DailyWorkoutTracker.API.Representations.Category;
using Equipment = DailyWorkoutTracker.API.Representations.Equipment;
using Exercise = DailyWorkoutTracker.API.Representations.Exercise;
using MuscleGroup = DailyWorkoutTracker.API.Representations.MuscleGroup;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DailyWorkoutTrackerContext>();
builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();
builder.Services.AddTransient<IMuscleGroupRepository, MuscleGroupRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IEquipmentRespository, EquipmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/exercises", async () =>
{
    var exerciseRepository = app.Services.GetRequiredService<IExerciseRepository>();
    var exercises = await exerciseRepository.GetAsync();

    return exercises
        .Select(e => new Exercise
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            MuscleGroups = e.ExerciseMuscleGroups?.Select(mg => new MuscleGroup
            {
                Id = mg.MuscleGroupId,
                Name = mg.MuscleGroup?.Name,
                Description = mg.MuscleGroup?.Description,
                ImageUrl = mg.MuscleGroup?.ImageUrl

            }).ToArray(),
            Equipment = e.ExerciseEquipments?.Select(eq => new Equipment
            {
                Id = eq.EquipmentId,
                Name = eq.Equipment?.Name,
                Description = eq.Equipment?.Description
            }).ToArray(),
            Category = e.ExerciseCategories?.Select(eq => new Category
            {
                Id = eq.CategoryId,
                Name = eq.Category?.Name,
                Description = eq.Category?.Description
            }).ToArray(),
            ImageUrl = e.ImageUrl
        })
        .ToArray();
})
.WithName("GetExercises")
.WithOpenApi();

app.MapPost("/exercises/seed", async () =>
{
    var exerciseRepository = app.Services.GetRequiredService<IExerciseRepository>();

    await exerciseRepository.Seed();
})
.WithName("SeedExercises")
.WithOpenApi();

app.MapPost("/categories/", async () =>
{
    var categoryRepository = app.Services.GetRequiredService<ICategoryRepository>();
    var categories = await categoryRepository.GetAsync();

    return categories.Select(c => new Category
    {
        Id = c.Id,
        Name = c.Name,
        Description = c.Description
    });

})
.WithName("GetCategories")
.WithOpenApi();

app.MapPost("/equipment/", async () =>
{
    var equipmentRepository = app.Services.GetRequiredService<IEquipmentRespository>();
    var equipment = await equipmentRepository.GetAsync();

    return equipment.Select(e => new Equipment
    {
        Id = e.Id,
        Name = e.Name,
        Description = e.Description
    });
})
.WithName("GetEquipment")
.WithOpenApi();

app.MapPost("/musclegroup/", async () =>
{
    var muscleGroupRepository = app.Services.GetRequiredService<IMuscleGroupRepository>();
    var muscleGroups = await muscleGroupRepository.GetAsync();

    return muscleGroups.Select(mg => new MuscleGroup
    {
        Id = mg.Id,
        Name = mg.Name,
        Description = mg.Description
    });
})
.WithName("GetMuscleGroup")
.WithOpenApi();

app.Run();