using AutoMapper;
using Azure.Core;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class GoalRepository : RepositoryBase<Goal>, IGoalRepository
    {
        private readonly IMapper _mapper;

        public GoalRepository(RepositoryContext repositoryContext, IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public Task<GoalTo> getById(long goalId)
        {
            Goal goal=FindByCondition(x => x.goal_id.Equals(goalId)).FirstOrDefault();
            return Task.FromResult(_mapper.Map<GoalTo>(goal));
        }
    }
}
