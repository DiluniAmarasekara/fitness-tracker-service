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
    public class GetAllCheatmealHandler : IRequestHandler<GetAllCheatmealQuery, List<CheatmealDto>>
    {
        private readonly ICheatmealRepository _cheatmealRepository;
        private readonly IMapper _mapper;

        public GetAllCheatmealHandler(ICheatmealRepository cheatmealRepository, IMapper mapper)
        {
            _cheatmealRepository = cheatmealRepository;
            _mapper = mapper;
        }

        public async Task<List<CheatmealDto>> Handle(GetAllCheatmealQuery request, CancellationToken cancellationToken)
        {
            List<CheatmealDto> responses = new List<CheatmealDto>();
            List<Cheatmeal> cheatmeals = await _cheatmealRepository.GetAllCheatmeals();

            cheatmeals.ForEach(cheatmeal =>
            {
                var response = _mapper.Map<CheatmealDto>(cheatmeal);
                responses.Add(response);
            });
            return responses;
        }
    }
}
