using AutoMapper;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories.Impl;
using fitness_tracker_service.Infrastructure.Persistence.Contexts;
using fitness_tracker_service.Infrastructure.Persistence.Entities;

namespace fitness_tracker_service.Infrastructure.Repositories.Impl
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
            Goal goal = FindByCondition(x => x.goal_id.Equals(goalId)).FirstOrDefault();
            return Task.FromResult(_mapper.Map<GoalTo>(goal));
        }

        public Task<bool> modify(Goal goal)
        {
            try
            {
                Update(goal);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
