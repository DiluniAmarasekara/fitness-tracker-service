namespace fitness_tracker_service.Domain.Models
{
    public class WorkoutExercise
    {
        public long exerciseId { get; set; }
        public long workoutId { get; set; }

        public WorkoutExercise(long exerciseId, long workoutId)
        {
            this.exerciseId = exerciseId;
            this.workoutId = workoutId;             
        }
    }
}
