using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface IWorkoutRepository
    {
        void delete(long workoutId);
        Task<List<WorkoutSchedule>> GetAllWorkouts();
        Task<WorkoutSchedule> GetWorkoutById(int workoutId);
        void save(WorkoutSchedule request);
        void update(WorkoutSchedule workoutSchedule);
    }
}
