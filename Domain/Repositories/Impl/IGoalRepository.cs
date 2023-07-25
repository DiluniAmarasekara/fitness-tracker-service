using fitness_tracker_service.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface IGoalRepository : IRepositoryBase<Goal>
    {
        Task<GoalTo> getById(long goalId);
        Task<bool> modify(Goal goal);
    }
}
