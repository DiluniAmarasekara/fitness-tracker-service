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
    public class GetAllExerciseHandler : IRequestHandler<GetAllExerciseQuery, List<ExerciseDto>>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public GetAllExerciseHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<List<ExerciseDto>> Handle(GetAllExerciseQuery request, CancellationToken cancellationToken)
        {
            List<ExerciseDto> responses = new List<ExerciseDto>();
            List<Exercise> exercises = await _exerciseRepository.GetAllExercise();

            exercises.ForEach(exercise =>
            {
                var response = _mapper.Map<ExerciseDto>(exercise);
                responses.Add(response);
            });
            return responses;
        }
    }
}
