using AutoMapper;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
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
