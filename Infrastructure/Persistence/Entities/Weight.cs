using System.ComponentModel.DataAnnotations.Schema;

namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    [Table("weight")]
    public class Weight
    {
        public long weight_id { get; set; }
        public DateTime log_date { get; set; }
        public double log_weight { get; set; }
        public long goal_id { get; set; }

        public Weight()
        {
        }
    }
}
