using fitness_tracker_service.Domain.Repositories.Impl;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface IRepositoryWrapper
    {
        IWorkoutRepository Workout { get; }
        IGoalRepository Goal { get; }
        ICheatmealRepository Cheatmeal { get; }
        IExerciseRepository Exercise { get; }
        IWorkoutExerciseRepository WorkoutExercise { get; }
        void Save();
    }
}
