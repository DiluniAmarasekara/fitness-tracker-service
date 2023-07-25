using System.ComponentModel.DataAnnotations.Schema;

namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    [Table("workout_exercise")]
    public class WorkoutExercise
    {
        public long exercise_id { get; set; }
        public long workout_id { get; set; }

        public WorkoutExercise(long exercise_id, long workout_id)
        {
            this.exercise_id = exercise_id;
            this.workout_id = workout_id;
        }
        public WorkoutExercise()
        { }
        }
}
