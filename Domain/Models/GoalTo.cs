﻿namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    public class GoalTo
    {
        public long goal_id { get; set; }
        public string purpose { get; set; }
        public int age { get; set; }
        public double current_height { get; set; }
        public double current_weight { get; set; }
        public double bmi { get; set; }
        public double goal_weight { get; set; }
    }
}