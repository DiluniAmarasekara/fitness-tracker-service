using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private readonly FitnessDbContext _dbContext;

        public GoalRepository(FitnessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Goal> GetGoalById(int goalId)
        {
            return _dbContext.findGoalById(goalId);
        }
    }
}
