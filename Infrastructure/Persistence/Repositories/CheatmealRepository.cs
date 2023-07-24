using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class CheatmealRepository : RepositoryBase<Cheatmeal>, ICheatmealRepository
    {
        public CheatmealRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
