using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface IExerciseRepository : IRepositoryBase<Exercise>
    {
        Task<List<ExerciseTo>> getAll();
        Task<ExerciseTo> getById(long exercise_id);
    }
}
