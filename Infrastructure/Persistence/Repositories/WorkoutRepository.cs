using AutoMapper;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class WorkoutRepository : RepositoryBase<Workout>, IWorkoutRepository
    {
        private readonly IMapper _mapper;
        public WorkoutRepository(RepositoryContext repositoryContext, IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public Task<bool> add(Workout workout)
        {
            try
            {
                Create(workout);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<List<WorkoutTo>> getAll()
        {
            IEnumerable<Workout> workouts = FindAll().ToList();
            return Task.FromResult(_mapper.Map<List<WorkoutTo>>(workouts.ToList()));
        }

        public Task<WorkoutTo> getById(long workout_id)
        {
            Workout workout=FindByCondition(x => x.workout_id.Equals(workout_id)).FirstOrDefault();
            return Task.FromResult(_mapper.Map<WorkoutTo>(workout));
        }

        public Task<bool> modify(Workout workout)
        {
            try
            {
                Update(workout);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> delete(Workout workout)
        {
            try
            {
                Delete(workout);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
