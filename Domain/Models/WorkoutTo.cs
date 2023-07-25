namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    public class WorkoutTo
    {
        public long workout_id { get; set; }
        public string workout_name { get; set; }
        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }
        public long goal_id { get; set; }
    }
}