using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Infrastructure.Persistence.Entities;

namespace fitness_tracker_service.Domain.Repositories.Impl
{
    public interface IWorkoutExerciseRepository : IRepositoryBase<WorkoutExercise>
    {
        Task<bool> addAll(long workout_id, List<Exercise> exercises);
        Task<bool> deleteAllByWorkoutId(List<WorkoutExercise> workoutExercises);
        Task<List<WorkoutExerciseTo>> getAllByWorkoutId(long workoutId);
    }
}
