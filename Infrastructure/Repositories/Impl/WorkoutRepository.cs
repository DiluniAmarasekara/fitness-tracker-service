using AutoMapper;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories.Impl;
using fitness_tracker_service.Infrastructure.Persistence.Contexts;
using fitness_tracker_service.Infrastructure.Persistence.Entities;

namespace fitness_tracker_service.Infrastructure.Repositories.Impl
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
            Workout workout = FindByCondition(x => x.workout_id.Equals(workout_id)).FirstOrDefault();
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

        public Task<List<WorkoutTo>> getAllByDateRange(DateTime from_date, DateTime to_date)
        {
            IEnumerable<Workout> workouts = FindByCondition(x => x.from_date >= from_date && x.to_date <= to_date).ToList();
            return Task.FromResult(_mapper.Map<List<WorkoutTo>>(workouts.ToList()));
        }
    }
}
