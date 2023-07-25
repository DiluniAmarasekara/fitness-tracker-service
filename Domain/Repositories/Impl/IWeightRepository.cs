using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Infrastructure.Persistence.Entities;

namespace fitness_tracker_service.Domain.Repositories.Impl
{
    public interface IWeightRepository : IRepositoryBase<Weight>
    {
        Task<bool> add(Weight weight);
        Task<List<WeightTo>> getAll();
        Task<List<WeightTo>> getAllByDateRange(DateTime from_date, DateTime to_date);
    }
}
