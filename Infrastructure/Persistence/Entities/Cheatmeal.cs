using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    [Table("cheat_meal")]
    public class Cheatmeal
    {
        public long cheat_id { get; set; }

        [Required(ErrorMessage = "Cheat Date is required")]
        public DateTime date_of_cheat { get; set; }
        public string meal { get; set; }

        [Required(ErrorMessage = "Workout ID is required")]
        public long workout_id { get; set; }
    }
}