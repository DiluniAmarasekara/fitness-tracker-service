using System.ComponentModel.DataAnnotations.Schema;

namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    [Table("workout_exercise")]
    public class WorkoutExercise
    {
        public long exercise_id { get; set; }
        public long workout_id { get; set; }
    }
}
