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
    public class GetAllWorkoutsHandler : IRequestHandler<GetAllWorkoutsQuery, List<WorkoutDto>>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;


        public GetAllWorkoutsHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<WorkoutDto>> Handle(GetAllWorkoutsQuery request, CancellationToken cancellationToken)
        {
            List<WorkoutDto> responses = new List<WorkoutDto>();
            List<Workout> workouts = _repository.Workout.FindAll().ToList();

            workouts.ForEach(workout =>
            {
                var response = _mapper.Map<WorkoutDto>(workout);
                responses.Add(response);
            });
            return responses;
        }
    }
}
