using AutoMapper;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class WeightRepository : RepositoryBase<Weight>, IWeightRepository
    {
        private readonly IMapper _mapper;
        public WeightRepository(RepositoryContext repositoryContext, IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public Task<bool> add(Weight weight)
        {
            try
            {
                Create(weight);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<List<WeightTo>> getAllByDateRange(DateTime from_date, DateTime to_date)
        {
            IEnumerable<Weight> weights = FindByCondition(x => x.log_date >= from_date && x.log_date <= to_date).ToList();
            return Task.FromResult(_mapper.Map<List<WeightTo>>(weights.ToList()));
        }
    }
}
