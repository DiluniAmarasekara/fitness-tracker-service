using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Application.Queries;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.QueryHandlers
{
    public class GetGoalByIdHandler : IRequestHandler<GetGoalByIdQuery, GoalDto>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public GetGoalByIdHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GoalDto> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
        {
            Goal goal = _repository.Goal.FindByCondition(x=>x.goal_id.Equals(request._goalId)).FirstOrDefault();
            return _mapper.Map<GoalDto>(goal);
        }
    }
}
