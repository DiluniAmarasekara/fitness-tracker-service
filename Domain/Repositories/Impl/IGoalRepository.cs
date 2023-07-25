using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Infrastructure.Persistence.Entities;

namespace fitness_tracker_service.Domain.Repositories.Impl
{
    public interface IGoalRepository : IRepositoryBase<Goal>
    {
        Task<GoalTo> getById(long goalId);
        Task<bool> modify(Goal goal);
    }
}
