using System;

namespace fitness_tracker_service.Application.Dtos
{
    public class ExerciseDto
    {
        public long exercise_id { get; set; }
        public string exercise_name { get; set; }
        public int reps { get; set; }

        public ExerciseDto()
        {
        }
    }
}