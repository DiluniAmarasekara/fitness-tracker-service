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
    public class GetAllExerciseHandler : IRequestHandler<GetAllExerciseQuery, List<ExerciseDto>>
    {
        private readonly IExerciseRepository _repository;
        private readonly IMapper _mapper;

        public GetAllExerciseHandler(IExerciseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ExerciseDto>> Handle(GetAllExerciseQuery request, CancellationToken cancellationToken)
        {
            List<ExerciseTo> exercises = await _repository.getAll();
            return _mapper.Map<List<ExerciseDto>>(exercises);
        }
    }
}
