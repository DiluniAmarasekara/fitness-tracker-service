using System;

namespace fitness_tracker_service.Application.Dtos
{
    public class GoalDto
    {
        public Int64 goalId { get; set; }
        public String purpose { get; set; }
        public int age { get; set; }
        public Double currentHeight { get; set; }
        public Double currentWeight { get; set; }
        public Double bmi { get; set; }
        public Double goalWeight { get; set; }

        public GoalDto(Int64 goalId, String purpose, int age, Double currentHeight, Double currentWeight, Double bmi, Double goalWeight)
        {
            this.goalId = goalId;
            this.purpose = purpose;
            this.age = age;
            this.currentHeight = currentHeight;
            this.currentWeight = currentWeight;
            this.bmi = bmi;
            this.goalWeight = goalWeight;
        }
    }
}