using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Infrastructure.Persistence.Entities;

namespace fitness_tracker_service.Domain.Repositories.Impl
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        Task<List<ExerciseTo>> getAll();
        Task<ExerciseTo> getById(long exercise_id);
    }
}
