using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using fitness_tracker_service.Infrastructure.Persistence.Repositories;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MediatR;
using System.Reflection.Metadata;
using Document = iTextSharp.text.Document;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class GenerateReportCommandHandler : IRequestHandler<GenerateReportCommand, string>
    {
        private readonly ICheatmealRepository _cheatRepository;
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IWeightRepository _weightRepository;

        public GenerateReportCommandHandler(IWeightRepository weightRepository, IExerciseRepository exerciseRepository, ICheatmealRepository cheatRepository, IWorkoutRepository workoutRepository)
        {
            _cheatRepository = cheatRepository;
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _weightRepository = weightRepository;
        }

        public async Task<string> Handle(GenerateReportCommand request, CancellationToken cancellationToken)
        {
            if (request.reportType.Equals(ReportType.Workout))
            {
                List<WorkoutTo> workouts = await _workoutRepository.getAllByDateRange(request.from_date, request.to_date);
                downloadPdfFile(ReportType.Exercise, workouts);
                return ReportType.Workout + " Report is generated successfully! Please check reports folder.";
            }
            else if (request.reportType.Equals(ReportType.CheatMeal))
            {
                List<CheatmealTo> cheatmeals = await _cheatRepository.getAllByDateRange(request.from_date, request.to_date);
                downloadPdfFile(ReportType.Exercise, cheatmeals);
                return ReportType.CheatMeal + " Report is generated successfully! Please check reports folder.";
            }
            else if (request.reportType.Equals(ReportType.Weight))
            {
                List<WeightTo> weights = await _weightRepository.getAllByDateRange(request.from_date, request.to_date);
                downloadPdfFile(ReportType.Exercise, weights);
                return ReportType.Weight + " Report is generated successfully! Please check reports folder.";
            }
            else {
                List<ExerciseTo> exercises = await _exerciseRepository.getAll();
                downloadPdfFile(ReportType.Exercise, exercises);
                return ReportType.Exercise + " Report is generated successfully! Please check reports folder.";
            }
            return "Report generate is failed!";
            
        }
        public void downloadPdfFile<T>(ReportType reportType, List<T> dataList)
        {
            // Create a new PDF document
            Document document = new Document();
            string filePath = setThePath(reportType);
            // Create a new PDF writer
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            // Open the PDF document
            document.Open();
            // Create a new PDF table with the number of columns equal to the number of properties in the T class
            PdfPTable table = new PdfPTable(typeof(T).GetProperties().Length);

            // Add the column headers to the PDF table
            foreach (var property in typeof(T).GetProperties())
            {
                PdfPCell cell = new PdfPCell(new Phrase(property.Name));
                table.AddCell(cell);
            }
            // Add the data rows from the dataList to the PDF table
            foreach (var data in dataList)
            {
                foreach (var property in typeof(T).GetProperties())
                {
                    PdfPCell cell = new PdfPCell(new Phrase(property.GetValue(data)?.ToString()));
                    table.AddCell(cell);
                }
            }
            // Add the PDF table to the PDF document
            document.Add(table);
            // Close the PDF document
            document.Close();
        }

        private string setThePath(ReportType reportType)
        {
            // Assuming the relative path to the "reports" folder
            string relativeReportsFolder = "reports";
            string fileName = reportType.ToString() + "_" + DateTime.Now + ".pdf";

            // Get the base directory of the application domain
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Combine the base directory with the relative path to the "reports" folder
            string reportsFolderPath = Path.Combine(baseDirectory, relativeReportsFolder);

            // Combine the "reports" folder path with the file name to get the full file path
            string fullFilePath = Path.Combine(reportsFolderPath, fileName);

            // Create the "reports" folder if it doesn't exist
            if (!Directory.Exists(reportsFolderPath))
            {
                Directory.CreateDirectory(reportsFolderPath);
            }
            return fullFilePath;
        }
    }
}
