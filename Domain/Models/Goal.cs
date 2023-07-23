using System;

namespace fitness_tracker_service.Domain.Models
{
    public class Goal
    {
        public long goalId { get; set; }
        public string purpose { get; set; }
        public int age { get; set; }
        public double currentHeight { get; set; }
        public double currentWeight { get; set; }
        public double bmi { get; set; }
        public double goalWeight { get; set; }

        public Goal(long goalId, string purpose, int age, double currentHeight, double currentWeight, double bmi, double goalWeight)
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