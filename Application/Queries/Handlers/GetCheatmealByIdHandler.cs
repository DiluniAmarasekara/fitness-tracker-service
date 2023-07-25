using AutoMapper;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Domain.Repositories.Impl;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.Queries.Handlers
{
    public class GetCheatmealByIdHandler : IRequestHandler<GetCheatmealByIdQuery, CheatmealDto>
    {
        private readonly ICheatmealRepository _repository;
        private readonly IMapper _mapper;

        public GetCheatmealByIdHandler(ICheatmealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CheatmealDto> Handle(GetCheatmealByIdQuery request, CancellationToken cancellationToken)
        {
            CheatmealTo cheatmeal = await _repository.getById(request._cheatmealId);
            return _mapper.Map<CheatmealDto>(cheatmeal);
        }
    }
}
