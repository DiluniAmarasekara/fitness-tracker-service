using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    [Table("workout")]
    public class Workout
    {
        public long workout_id { get; set; }

        [Required(ErrorMessage = "Workout name is required")]
        [StringLength(60, ErrorMessage = "Workout name can't be longer than 60 characters")]
        public string workout_name { get; set; }
        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }

        [Required(ErrorMessage = "Goal ID is required")]
        public long goal_id { get; set; }
        public Workout()
        {
            
        }
    }
}