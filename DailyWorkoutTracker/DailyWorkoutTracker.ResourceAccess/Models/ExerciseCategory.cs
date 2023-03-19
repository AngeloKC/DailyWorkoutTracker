﻿namespace DailyWorkoutTracker.ResourceAccess.Models
{
    public class ExerciseCategory
    {
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
