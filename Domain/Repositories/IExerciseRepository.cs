using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllExercise();
        Task<List<Exercise>> GetAllExerciseByWorkoutId(int _workoutId);
        void saveAll(List<WorkoutExercise> workoutExercises);
        void updateAll(long workoutId, List<WorkoutExercise> workoutExercises);
    }
}
