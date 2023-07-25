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
    public class GetAllCheatmealHandler : IRequestHandler<GetAllCheatmealQuery, List<CheatmealDto>>
    {
        private readonly ICheatmealRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCheatmealHandler(ICheatmealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CheatmealDto>> Handle(GetAllCheatmealQuery request, CancellationToken cancellationToken)
        {
            List<CheatmealTo> cheatmeals = await _repository.getAll();
            return _mapper.Map<List<CheatmealDto>>(cheatmeals);
        }
    }
}
