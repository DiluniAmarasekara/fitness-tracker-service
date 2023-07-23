using fitness_tracker_service.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface IWorkoutRepository
    {
        Task<List<WorkoutSchedule>> GetAllWorkouts();
        Task<WorkoutSchedule> GetWorkoutById(int workoutId);
    }
}
