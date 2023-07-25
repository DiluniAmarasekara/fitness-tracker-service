using AutoMapper;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories.Impl;
using fitness_tracker_service.Infrastructure.Persistence.Contexts;
using fitness_tracker_service.Infrastructure.Persistence.Entities;

namespace fitness_tracker_service.Infrastructure.Repositories.Impl
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        private readonly IMapper _mapper;

        public ExerciseRepository(RepositoryContext repositoryContext, IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public Task<List<ExerciseTo>> getAll()
        {
            IEnumerable<Exercise> exercises = FindAll().ToList();
            return Task.FromResult(_mapper.Map<List<ExerciseTo>>(exercises.ToList()));
        }

        public Task<ExerciseTo> getById(long exercise_id)
        {
            Exercise exercise=FindByCondition(x => x.exercise_id.Equals(exercise_id)).FirstOrDefault();
            return Task.FromResult(_mapper.Map<ExerciseTo>(exercise));
        }
    }
}
