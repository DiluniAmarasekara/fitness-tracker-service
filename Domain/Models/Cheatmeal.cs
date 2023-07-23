using System;

namespace fitness_tracker_service.Domain.Models
{
    public class Cheatmeal
    {
        public long cheatId { get; set; }
        public DateTime dateOfCheat { get; set; }
        public string calories { get; set; }
        public long workoutId { get; set; }

        public Cheatmeal(long cheatId, DateTime dateOfCheat, string calories, long workoutId)
        {
            this.cheatId = cheatId;
            this.dateOfCheat = dateOfCheat;
            this.calories = calories;
            this.workoutId = workoutId;
        }
    }
}