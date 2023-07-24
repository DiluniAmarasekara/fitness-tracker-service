using System;

namespace fitness_tracker_service.Application.Dtos
{
    public class ExerciseDto
    {
        public Int64 exercise_id { get; set; }
        public string exercise_name { get; set; }
        public int reps { get; set; }

        public ExerciseDto()
        {
        }

        public ExerciseDto(Int64 exerciseId, string exerciseName, int reps)
        {
            this.exercise_id = exerciseId;
            this.exercise_name = exerciseName;
            this.reps = reps;
        }
    }
}