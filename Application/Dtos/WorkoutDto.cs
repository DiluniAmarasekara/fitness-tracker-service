using System;

namespace fitness_tracker_service.Application.Dtos
{
    public class WorkoutDto
    {
        public long workoutId { get; set; }
        public string workoutName { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public long goalId { get; set; }

        public WorkoutDto(long workoutId, string workoutName, DateTime fromDate, DateTime toDate, long goalId)
        {
            this.workoutId = workoutId;
            this.workoutName = workoutName;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.goalId = goalId;
        }
    }
}