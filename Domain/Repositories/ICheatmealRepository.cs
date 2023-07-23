using fitness_tracker_service.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface ICheatmealRepository
    {
        Task<List<Cheatmeal>> GetAllCheatmeals();
        Task<Cheatmeal> GetCheatmealById(int cheatmealId);
    }
}
