using AutoMapper;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories.Impl;
using fitness_tracker_service.Infrastructure.Persistence.Contexts;
using fitness_tracker_service.Infrastructure.Persistence.Entities;

namespace fitness_tracker_service.Infrastructure.Repositories.Impl
{
    public class WorkoutExerciseRepository : RepositoryBase<WorkoutExercise>, IWorkoutExerciseRepository
    {
        private readonly IMapper _mapper;
        public WorkoutExerciseRepository(RepositoryContext repositoryContext, IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public Task<bool> addAll(long workout_id, List<Exercise> exercises)
        {
            try
            {
                exercises.ForEach(exercise =>
                {
                    WorkoutExercise workoutExercise = new WorkoutExercise(exercise.exercise_id, workout_id);
                    Create(workoutExercise);
                });

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> deleteAllByWorkoutId(List<WorkoutExercise> workoutExercises)
        {
            try
            {
                workoutExercises.ForEach(exercise =>
                {
                    Delete(exercise);
                });

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<List<WorkoutExerciseTo>> getAllByWorkoutId(long workoutId)
        {
            IEnumerable<WorkoutExercise> exercises = FindByCondition(x => x.workout_id.Equals(workoutId)).ToList();
            return Task.FromResult(_mapper.Map<List<WorkoutExerciseTo>>(exercises.ToList()));
        }
    }
}
