using System;

namespace fitness_tracker_service.Domain.Models
{
    public class Exercise
    {
        public long exerciseId { get; set; }
        public string exerciseName { get; set; }
        public int reps { get; set; }

        public Exercise(long exerciseId, string exerciseName, int reps)
        {
            this.exerciseId = exerciseId;
            this.exerciseName = exerciseName;
            this.reps = reps;
        }
    }
}