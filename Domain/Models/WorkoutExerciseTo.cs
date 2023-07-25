namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    public class WorkoutExerciseTo
    {
        public long exercise_id { get; set; }
        public long workout_id { get; set; }

        public WorkoutExerciseTo(long exercise_id, long workout_id)
        {
            this.exercise_id = exercise_id;
            this.workout_id = workout_id;
        }
        public WorkoutExerciseTo()
        { }
        }
}
