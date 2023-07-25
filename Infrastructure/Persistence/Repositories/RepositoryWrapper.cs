using AutoMapper;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IMapper _mapper;
        private RepositoryContext _repoContext;
        private IWorkoutRepository _workout;
        private IGoalRepository _goal;
        private ICheatmealRepository _cheatmeal;
        private IExerciseRepository _exercise;
        private IWorkoutExerciseRepository _workoutExercise;
        public IWorkoutRepository Workout
        {
            get
            {
                if (_workout == null)
                {
                    _workout = new WorkoutRepository(_repoContext, _mapper);
                }
                return _workout;
            }
        }

        public IGoalRepository Goal
        {
            get
            {
                if (_goal == null)
                {
                    _goal = new GoalRepository(_repoContext, _mapper);
                }
                return _goal;
            }
        }

        public ICheatmealRepository Cheatmeal
        {
            get
            {
                if (_cheatmeal == null)
                {
                    _cheatmeal = new CheatmealRepository(_repoContext, _mapper);
                }
                return _cheatmeal;
            }
        }

        public IExerciseRepository Exercise
        {
            get
            {
                if (_exercise == null)
                {
                    _exercise = new ExerciseRepository(_repoContext, _mapper);
                }
                return _exercise;
            }
        }

        public IWorkoutExerciseRepository WorkoutExercise
        {
            get
            {
                if (_workoutExercise == null)
                {
                    _workoutExercise = new WorkoutExerciseRepository(_repoContext, _mapper);
                }
                return _workoutExercise;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
