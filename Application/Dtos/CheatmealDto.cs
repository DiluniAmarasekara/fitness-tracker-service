using System;
using System.ComponentModel.DataAnnotations;

namespace fitness_tracker_service.Application.Dtos
{
    public class CheatmealDto
    {
        public long cheat_id { get; set; }

        public DateTime date_of_cheat { get; set; }

        public string meal { get; set; }

        public long workout_id { get; set; }

        public CheatmealDto()
        {
        }

        public CheatmealDto(long cheatId, DateTime dateOfCheat, string calories, long workoutId)
        {
            this.cheat_id = cheatId;
            this.date_of_cheat = dateOfCheat;
            this.meal = calories;
            this.workout_id = workoutId;
        }
    }
}