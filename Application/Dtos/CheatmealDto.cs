using System;

namespace fitness_tracker_service.Application.Dtos
{
    public class CheatmealDto
    {
        public long cheatId { get; set; }
        public DateTime dateOfCheat { get; set; }
        public string calories { get; set; }
        public long workoutId { get; set; }

        public CheatmealDto(long cheatId, DateTime dateOfCheat, string calories, long workoutId)
        {
            this.cheatId = cheatId;
            this.dateOfCheat = dateOfCheat;
            this.calories = calories;
            this.workoutId = workoutId;
        }
    }
}