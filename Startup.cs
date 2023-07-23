using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Application.Commands;

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
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ICheatmealRepository, CheatmealRepository>();
            services.AddScoped<FitnessDbContext>();
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Goal, GoalDto>();
                config.CreateMap<WorkoutSchedule, WorkoutDto>();
                config.CreateMap<CreateUpdateDeleteWorkoutCommand, WorkoutSchedule>();
                config.CreateMap<Exercise, ExerciseDto>();
                config.CreateMap<Cheatmeal, CheatmealDto>();
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
