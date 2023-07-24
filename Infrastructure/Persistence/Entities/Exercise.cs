using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitness_tracker_service.Infrastructure.Persistence.Entities
{
    [Table("exercise")]
    public class Exercise
    {
        public long exercise_id { get; set; }
        public string exercise_name { get; set; }
        public int reps { get; set; }
    }
}