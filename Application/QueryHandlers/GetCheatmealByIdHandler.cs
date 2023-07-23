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
    public class GetCheatmealByIdHandler : IRequestHandler<GetCheatmealByIdQuery, CheatmealDto>
    {
        private readonly ICheatmealRepository _cheatmealRepository;
        private readonly IMapper _mapper;

        public GetCheatmealByIdHandler(ICheatmealRepository cheatmealRepository, IMapper mapper)
        {
            _cheatmealRepository = cheatmealRepository;
            _mapper = mapper;
        }

        public async Task<CheatmealDto> Handle(GetCheatmealByIdQuery request, CancellationToken cancellationToken)
        {
            Cheatmeal cheatmeal = await _cheatmealRepository.GetCheatmealById(request._cheatmealId);
            return _mapper.Map<CheatmealDto>(cheatmeal);
        }
    }
}
