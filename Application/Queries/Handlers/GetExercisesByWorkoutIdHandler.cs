using AutoMapper;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Domain.Repositories.Impl;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.Queries.Handlers
{
    public class GetExercisesByWorkoutIdHandler : IRequestHandler<GetExercisesByWorkoutIdQuery, List<ExerciseDto>>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IWorkoutExerciseRepository _workoutExerciseRepository;
        private readonly IMapper _mapper;

        public GetExercisesByWorkoutIdHandler(IExerciseRepository exerciseRepository, IWorkoutExerciseRepository workoutExerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _workoutExerciseRepository = workoutExerciseRepository;
            _mapper = mapper;
        }

        public async Task<List<ExerciseDto>> Handle(GetExercisesByWorkoutIdQuery request, CancellationToken cancellationToken)
        {
            List<ExerciseDto> responses=new List<ExerciseDto>();
            List<WorkoutExerciseTo> workoutExercises = await _workoutExerciseRepository.getAllByWorkoutId(request._workoutId);
            workoutExercises.ForEach(async exercise =>
            {
                ExerciseTo exerciseTo = await _exerciseRepository.getById(exercise.exercise_id);
                var response = _mapper.Map<ExerciseDto>(exerciseTo);
                responses.Add(response);
            });
            return responses;
        }
    }
}
