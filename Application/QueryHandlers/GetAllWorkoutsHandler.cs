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
    public class GetAllWorkoutsHandler : IRequestHandler<GetAllWorkoutsQuery, List<WorkoutDto>>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;


        public GetAllWorkoutsHandler(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public async Task<List<WorkoutDto>> Handle(GetAllWorkoutsQuery request, CancellationToken cancellationToken)
        {
            List<WorkoutDto> responses = new List<WorkoutDto>();
            List<WorkoutSchedule> workouts = await _workoutRepository.GetAllWorkouts();

            workouts.ForEach(workout =>
            {
                var response = _mapper.Map<WorkoutDto>(workout);
                responses.Add(response);
            });
            return responses;
        }
    }
}
