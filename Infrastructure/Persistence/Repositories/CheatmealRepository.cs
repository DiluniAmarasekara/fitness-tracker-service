using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class CheatmealRepository : ICheatmealRepository
    {
        private readonly FitnessDbContext _dbContext;

        public CheatmealRepository(FitnessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void delete(long cheatId)
        {
            _dbContext.deleteCheatmeal(cheatId);
        }

        public Task<List<Cheatmeal>> GetAllCheatmeals()
        {
            return _dbContext.findAllCheatmealsByWorkoutIdOpt((long)0.0);
        }
        public Task<Cheatmeal> GetCheatmealById(int cheatmealId)
        {
            return _dbContext.findCheatmealById(cheatmealId);
        }

        public void save(Cheatmeal cheatmeal)
        {
            _dbContext.save(cheatmeal);
        }

        public void update(Cheatmeal cheatmeal)
        {
            _dbContext.update(cheatmeal);
        }
    }
}
