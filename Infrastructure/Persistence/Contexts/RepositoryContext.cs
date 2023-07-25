using fitness_tracker_service.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace fitness_tracker_service.Infrastructure.Persistence.Contexts
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Goal>? Goals { get; set; }
        public DbSet<Workout>? Workouts { get; set; }
        public DbSet<Exercise>? Exercises { get; set; }
        public DbSet<Cheatmeal>? Cheatmeals { get; set; }
        public DbSet<WorkoutExercise>? WorkoutExercises { get; set; }
        public DbSet<Weight>? Weights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goal>().HasKey(x => x.goal_id);
            modelBuilder.Entity<Workout>().HasKey(x => x.workout_id);
            modelBuilder.Entity<Exercise>().HasKey(x => x.exercise_id);
            modelBuilder.Entity<Cheatmeal>().HasKey(x => x.cheat_id);
            modelBuilder.Entity<WorkoutExercise>().HasKey(x => new { x.workout_id, x.exercise_id });
            modelBuilder.Entity<Weight>().HasKey(x => x.weight_id);
        }
    }
}
