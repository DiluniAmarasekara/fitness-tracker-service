using MediatR;
using Microsoft.OpenApi.Models;
using AutoMapper;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using fitness_tracker_service.Infrastructure.Services;
using fitness_tracker_service.Domain.Models;
using System.ComponentModel;

namespace fitness_tracker_service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.ConfigureSqlServerContext(Configuration);
            services.ConfigureRepositoryWrapper();

            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ICheatmealRepository, CheatmealRepository>();
            services.AddScoped<IWorkoutExerciseRepository, WorkoutExerciseRepository>();
            services.AddScoped<IWeightRepository, WeightRepository>();

            services.AddScoped<RepositoryContext>();

            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateWorkoutCommand, Workout>();
                config.CreateMap<UpdateWorkoutCommand, Workout>();
                config.CreateMap<CreateCheatmealCommand, Cheatmeal>();
                config.CreateMap<UpdateCheatmealCommand, Cheatmeal>();

                config.CreateMap<ExerciseTo, ExerciseDto>();
                config.CreateMap<Exercise, ExerciseTo>();
                config.CreateMap<ExerciseTo, Exercise>();
                config.CreateMap<ExerciseDto, Exercise>();

                config.CreateMap<CheatmealTo, CheatmealDto>();
                config.CreateMap<Cheatmeal, CheatmealTo>();
                config.CreateMap<CheatmealTo, Cheatmeal>();

                config.CreateMap<WorkoutTo, WorkoutDto>();
                config.CreateMap<Workout, WorkoutTo>();
                config.CreateMap<WorkoutTo, Workout>();

                config.CreateMap<GoalTo, GoalDto>();
                config.CreateMap<Goal, GoalTo>();
                config.CreateMap<GoalTo, Goal>();

                config.CreateMap<WorkoutExercise, WorkoutExerciseTo>();
                config.CreateMap<WorkoutExerciseTo, WorkoutExercise>();

                config.CreateMap<WeightTo, Weight>();
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fitness Tracker API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fitness Tracker V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
