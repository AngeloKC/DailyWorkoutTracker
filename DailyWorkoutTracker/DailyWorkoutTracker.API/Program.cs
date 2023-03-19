using DailyWorkoutTracker.API.Representations;
using DailyWorkoutTracker.ResourceAccess;
using DailyWorkoutTracker.ResourceAccess.Models;
using DailyWorkoutTracker.ResourceAccess.Repositories;
using System.Linq;
using Equipment = DailyWorkoutTracker.API.Representations.Equipment;
using Exercise = DailyWorkoutTracker.API.Representations.Exercise;
using MuscleGroup = DailyWorkoutTracker.API.Representations.MuscleGroup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DailyWorkoutTrackerContext>();
builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

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
            Equipment = null,
            ImageUrl = e.ImageUrl
        })
        .ToArray();
});

app.MapPost("/exercises/seed", () =>
{
    var exerciseRepository = app.Services.GetRequiredService<IExerciseRepository>();

    return exerciseRepository.Seed();
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
