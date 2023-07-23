using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using fitness_tracker_service.Domain.Models;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers
{
    public class FitnessDbContext
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection cn;

        public FitnessDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            cn = new SqlConnection(_configuration.GetConnectionString("FitnessCon").ToString());
        }

        internal Task<List<Cheatmeal>> findAllCheatmeals()
        {
            List<Cheatmeal> cheatmeals = new List<Cheatmeal>();
            SqlCommand cmd = new SqlCommand("select * from cheat_meal", cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string format = "M/d/yyyy h:mm:ss tt";
                Cheatmeal cheatmealObj = new Cheatmeal((Int64)dt.Rows[i]["cheat_id"],
                    DateTime.ParseExact(dt.Rows[i]["date_of_cheat"].ToString(), format, CultureInfo.InvariantCulture),
                    dt.Rows[i]["meal"].ToString(), (Int64)dt.Rows[i]["workout_id"]);
                cheatmeals.Add(cheatmealObj);
            }
            return Task.FromResult(cheatmeals);
        }

        internal Task<List<Exercise>> findAllExercise()
        {
            List<Exercise> exercises=new List<Exercise>();
            SqlCommand cmd = new SqlCommand("select * from exercise", cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Exercise exsercise = new Exercise((Int64)dt.Rows[i]["exercise_id"], dt.Rows[i]["exercise_name"].ToString(), (int)dt.Rows[i]["reps"]);
                exercises.Add(exsercise);
            }
            return Task.FromResult(exercises);
        }

        internal Task<List<Exercise>> findAllExerciseByWorkoutId(int workoutId)
        {
            List<Exercise> exercises = new List<Exercise>();
            SqlCommand cmd = new SqlCommand("select e.exercise_id, e.exercise_name, e.reps from exercise e left join workout_exercise we on e.exercise_id=we.exercise_id where we.workout_id=@workout_id", cn);
            cmd.Parameters.AddWithValue("workout_id", workoutId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Exercise exsercise = new Exercise((Int64)dt.Rows[i]["exercise_id"], dt.Rows[i]["exercise_name"].ToString(), (int)dt.Rows[i]["reps"]);
                exercises.Add(exsercise);
            }
            return Task.FromResult(exercises);
        }

        internal Task<List<WorkoutSchedule>> findAllWorkouts()
        {
            List<WorkoutSchedule> workoutItems = new List<WorkoutSchedule>();
            SqlCommand cmd = new SqlCommand("select * from workout", cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string format = "M/d/yyyy h:mm:ss tt";
                WorkoutSchedule workoutObj = new WorkoutSchedule((long)dt.Rows[i]["workout_id"], dt.Rows[i]["workout_name"].ToString(),
                    DateTime.ParseExact(dt.Rows[i]["from_date"].ToString(), format, CultureInfo.InvariantCulture),
                    DateTime.ParseExact(dt.Rows[i]["to_date"].ToString(), format, CultureInfo.InvariantCulture), (long)dt.Rows[i]["goal_id"]);
                workoutItems.Add(workoutObj);
            }
            return Task.FromResult(workoutItems);
        }

        internal Task<Cheatmeal> findCheatmealById(int cheatmealId)
        {
            SqlCommand cmd = new SqlCommand("select * from cheat_meal where cheat_id=@cheat_id", cn);
            cmd.Parameters.AddWithValue("cheat_id", cheatmealId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string format = "M/d/yyyy h:mm:ss tt";
                Cheatmeal cheatmealObj = new Cheatmeal((Int64)dt.Rows[0]["cheat_id"],
                    DateTime.ParseExact(dt.Rows[0]["date_of_cheat"].ToString(), format, CultureInfo.InvariantCulture),
                    dt.Rows[0]["meal"].ToString(), (Int64)dt.Rows[0]["workout_id"]); 
                return Task.FromResult(cheatmealObj);
            }
            else
            {
                return Task.FromResult<Cheatmeal>(null);
            }
        }

        internal Task<Goal> findGoalById(int goalId)
        {
            SqlCommand cmd = new SqlCommand("select * from goal", cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Goal goalObj = new Goal((long)dt.Rows[0]["goal_id"], (string)dt.Rows[0]["purpose"], (int)dt.Rows[0]["age"], (double)dt.Rows[0]["current_height"],
                   (double)dt.Rows[0]["current_weight"], (double)dt.Rows[0]["bmi"], (double)dt.Rows[0]["goal_weight"]);
                return Task.FromResult(goalObj);
            }
            else
            {
                return Task.FromResult<Goal>(null);
            }
        }

        internal Task<WorkoutSchedule> findWorkoutById(int workoutId)
        {
            SqlCommand cmd = new SqlCommand("select * from workout where workout_id=@workout_id", cn);
            cmd.Parameters.AddWithValue("workout_id", workoutId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string format = "M/d/yyyy h:mm:ss tt";
                WorkoutSchedule workoutObj = new WorkoutSchedule((long)dt.Rows[0]["workout_id"], dt.Rows[0]["workout_name"].ToString(),
                    DateTime.ParseExact(dt.Rows[0]["from_date"].ToString(), format, CultureInfo.InvariantCulture),
                    DateTime.ParseExact(dt.Rows[0]["to_date"].ToString(), format, CultureInfo.InvariantCulture), (long)dt.Rows[0]["goal_id"]);
                return Task.FromResult(workoutObj);
            }
            else
            {
                return Task.FromResult<WorkoutSchedule>(null);
            }
        }
    }
}
