using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface IWorkoutRepository : IRepositoryBase<Workout>
    {
        Task<bool> add(Workout workout);
        Task<bool> delete(Workout workout);
        Task<List<WorkoutTo>> getAll();
        Task<List<WorkoutTo>> getAllByDateRange(DateTime from_date, DateTime to_date);
        Task<WorkoutTo> getById(long workout_id);
        Task<bool> modify(Workout workout);
    }
}
