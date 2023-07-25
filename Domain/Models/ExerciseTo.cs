namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    public class ExerciseTo
    {
        public long exercise_id { get; set; }
        public string exercise_name { get; set; }
        public int reps { get; set; }

        public ExerciseTo()
        {
        }
    }
}