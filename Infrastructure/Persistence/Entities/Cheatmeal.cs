using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    [Table("cheat_meal")]
    public class Cheatmeal
    {
        public long cheat_id { get; set; }
        public DateTime date_of_cheat { get; set; }
        public string meal { get; set; }
        public long workout_id { get; set; }
    }
}