using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Application.Queries;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using MediatR;

namespace fitness_tracker_service.Application.QueryHandlers
{
    public class GetGoalByIdHandler : IRequestHandler<GetGoalByIdQuery, GoalDto>
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;


        public GetGoalByIdHandler(IGoalRepository goalRepository, IMapper mapper)
        {
            _goalRepository = goalRepository;
            _mapper = mapper;
        }

        public async Task<GoalDto> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
        {
            Goal goal = await _goalRepository.GetGoalById(request._goalId);
            return _mapper.Map<GoalDto>(goal);
        }
    }
}
