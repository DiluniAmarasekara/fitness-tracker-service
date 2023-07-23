using System;

namespace fitness_tracker_service.Application.Dtos
{
    public class ExerciseDto
    {
        public Int64 exerciseId { get; set; }
        public string exerciseName { get; set; }
        public int reps { get; set; }

        public ExerciseDto(Int64 exerciseId, string exerciseName, int reps)
        {
            this.exerciseId = exerciseId;
            this.exerciseName = exerciseName;
            this.reps = reps;
        }
    }
}