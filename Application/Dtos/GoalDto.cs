using System;

namespace fitness_tracker_service.Application.Dtos
{
    public class GoalDto
    {
        public long goal_id { get; set; }
        public string purpose { get; set; }
        public int age { get; set; }
        public double current_height { get; set; }
        public double current_weight { get; set; }
        public double bmi { get; set; }
        public double goal_weight { get; set; }

        public GoalDto()
        {
        }

        public GoalDto(Int64 goalId, String purpose, int age, Double currentHeight, Double currentWeight, Double bmi, Double goalWeight)
        {
            this.goal_id = goalId;
            this.purpose = purpose;
            this.age = age;
            this.current_height = currentHeight;
            this.current_weight = currentWeight;
            this.bmi = bmi;
            this.goal_weight = goalWeight;
        }
    }
}