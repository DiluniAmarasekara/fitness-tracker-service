﻿using System.Collections.Generic;
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
        private readonly IGoalRepository _repository;
        private readonly IMapper _mapper;

        public GetGoalByIdHandler(IGoalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GoalDto> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
        {
            GoalTo goal = await _repository.getById(request._goalId);
            return _mapper.Map<GoalDto>(goal);
        }
    }
}
