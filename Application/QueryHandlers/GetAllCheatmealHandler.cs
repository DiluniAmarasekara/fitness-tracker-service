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
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public GetAllCheatmealHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CheatmealDto>> Handle(GetAllCheatmealQuery request, CancellationToken cancellationToken)
        {
            List<CheatmealDto> responses = new List<CheatmealDto>();
            List<Cheatmeal> cheatmeals = _repository.Cheatmeal.FindAll().ToList();

            cheatmeals.ForEach(cheatmeal =>
            {
                var response = _mapper.Map<CheatmealDto>(cheatmeal);
                responses.Add(response);
            });
            return responses;
        }
    }
}
