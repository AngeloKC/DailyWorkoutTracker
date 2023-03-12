using DailyWorkoutTracker.API.Models;
using DailyWorkoutTracker.API.Repositories;

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

// add exercise endpoint
app.MapGet("/exercise", () =>
{
    var exercises = new List<Exercise>();

    var exercise = new Exercise
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
    };

    exercises.Add(exercise);

    return exercises;

});


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
