namespace fitness_tracker_service.Domain.Models
{
    public class WeightTo
    {
        public long weight_id { get; set; }
        public DateTime log_date { get; set; }
        public double log_weight { get; set; }
        public long goal_id { get; set; }

        public WeightTo()
        {
        }
        public WeightTo(long goal_id, DateTime log_date, double log_weight)
        {
            this.goal_id= goal_id;
            this.log_date= log_date;
            this.log_weight= log_weight;
        }
    }
}
