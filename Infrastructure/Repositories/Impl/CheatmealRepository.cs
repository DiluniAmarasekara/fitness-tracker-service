using AutoMapper;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories.Impl;
using fitness_tracker_service.Infrastructure.Persistence.Contexts;
using fitness_tracker_service.Infrastructure.Persistence.Entities;

namespace fitness_tracker_service.Infrastructure.Repositories.Impl
{
    public class CheatmealRepository : RepositoryBase<Cheatmeal>, ICheatmealRepository
    {
        private readonly IMapper _mapper;
        public CheatmealRepository(RepositoryContext repositoryContext, IMapper mapper)
            : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public Task<bool> add(Cheatmeal cheatmeal)
        {
            try
            {
                Create(cheatmeal);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> delete(Cheatmeal cheatmeal)
        {
            try
            {
                Delete(cheatmeal);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> deleteAllByWorkoutId(List<Cheatmeal> cheatmeals)
        {
            try
            {
                cheatmeals.ForEach(cheatmeal =>
                {
                    Delete(cheatmeal);
                });

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public Task<List<CheatmealTo>> getAll()
        {
            IEnumerable<Cheatmeal> cheatmeals = FindAll().ToList();
            return Task.FromResult(_mapper.Map<List<CheatmealTo>>(cheatmeals.ToList()));
        }

        public Task<List<CheatmealTo>> getAllByDateRange(DateTime from_date, DateTime to_date)
        {
            IEnumerable<Cheatmeal> cheatmeals = FindByCondition(x => x.date_of_cheat >= from_date && x.date_of_cheat <= to_date).ToList();
            return Task.FromResult(_mapper.Map<List<CheatmealTo>>(cheatmeals.ToList()));
        }

        public Task<List<CheatmealTo>> getAllByWorkoutId(long workoutId)
        {
            IEnumerable<Cheatmeal> cheatmeals = FindByCondition(x => x.workout_id.Equals(workoutId)).ToList();
            return Task.FromResult(_mapper.Map<List<CheatmealTo>>(cheatmeals.ToList()));
        }

        public Task<CheatmealTo> getById(long cheatmealId)
        {
            Cheatmeal cheatmeal = FindByCondition(x => x.cheat_id.Equals(cheatmealId)).FirstOrDefault();
            return Task.FromResult(_mapper.Map<CheatmealTo>(cheatmeal));
        }

        public Task<bool> modify(Cheatmeal cheatmeal)
        {
            try
            {
                Update(cheatmeal);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
