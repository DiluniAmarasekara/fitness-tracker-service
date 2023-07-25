using fitness_tracker_service.Infrastructure.Persistence.Entities;

namespace fitness_tracker_service.Domain.Repositories
{
    public interface ICheatmealRepository : IRepositoryBase<Cheatmeal>
    {
        Task<bool> add(Cheatmeal cheatmeal);
        Task<bool> delete(Cheatmeal cheatmeal);
        Task<bool> deleteAllByWorkoutId(List<Cheatmeal> cheatmeals);
        Task<List<CheatmealTo>> getAll();
        Task<List<CheatmealTo>> getAllByDateRange(DateTime from_date, DateTime to_date);
        Task<List<CheatmealTo>> getAllByWorkoutId(long workoutId);
        Task<CheatmealTo> getById(long cheatmealId);
        Task<bool> modify(Cheatmeal cheatmeal);
    }
}
