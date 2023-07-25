namespace fitness_tracker_service.Domain.Models
{
    public class CheatmealTo
    {
        public long cheat_id { get; set; }
        public DateTime date_of_cheat { get; set; }
        public string meal { get; set; }
        public long workout_id { get; set; }

        public CheatmealTo()
        {
        }
    }
}