using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface IWorkoutRepository : IRepositoryBase<Workout>
    {
    }
}
