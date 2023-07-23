using fitness_tracker_service.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllExercise();
        Task<List<Exercise>> GetAllExerciseByWorkoutId(int _workoutId);
    }
}
