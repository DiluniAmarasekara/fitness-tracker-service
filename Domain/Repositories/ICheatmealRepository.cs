using fitness_tracker_service.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface ICheatmealRepository
    {
        void delete(long cheatId);
        Task<List<Cheatmeal>> GetAllCheatmeals();
        Task<Cheatmeal> GetCheatmealById(int cheatmealId);
        void save(Cheatmeal cheatmeal);
        void update(Cheatmeal cheatmeal);
    }
}
