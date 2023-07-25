namespace fitness_tracker_service.Domain.Models
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