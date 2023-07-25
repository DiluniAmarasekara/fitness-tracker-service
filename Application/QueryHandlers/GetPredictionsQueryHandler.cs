using AutoMapper;
using fitness_tracker_service.Application.Queries;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using MediatR;

namespace fitness_tracker_service.Application.QueryHandlers
{
    public class GetPredictionsQueryHandler : IRequestHandler<GetPredictionsQuery, List<double>>
    {
        private readonly IWeightRepository _repository;
        private readonly IMapper _mapper;

        public GetPredictionsQueryHandler(IWeightRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<double>> Handle(GetPredictionsQuery request, CancellationToken cancellationToken)
        {
            List<WeightTo> weightTos = await _repository.getAll();
            Dictionary<long, WeightTo> weightMap = weightTos.ToDictionary(w => w.weight_id, w => w);

            // Assuming you have a list of weight observations with corresponding time points
            List<long> timePoints = new List<long>(weightMap.Keys);
            List<double> weights = new List<double>();

            foreach (KeyValuePair<long, WeightTo> pair in weightMap)
            {
                weights.Add(pair.Value.log_weight);
            }

            // Predict future weight values
            List<int> futureTimePoints = Enumerable.Range(timePoints.Count, timePoints.Count + 50).ToList();
            return PredictWeights(weights, timePoints, futureTimePoints);
        }

        private List<double> PredictWeights(List<double> weights, List<long> timePoints, List<int> futureTimePoints)
        {
            // Perform linear regression
            double[] x = timePoints.Select(Convert.ToDouble).ToArray();
            double[] y = weights.ToArray();

            double sumX = x.Sum();
            double sumY = y.Sum();
            double sumXY = x.Zip(y, (a, b) => a * b).Sum();
            double sumXX = x.Zip(x, (a, b) => a * b).Sum();
            double n = weights.Count;

            double slope = (n * sumXY - sumX * sumY) / (n * sumXX - sumX * sumX);
            double intercept = (sumY - slope * sumX) / n;

            // Predict the weights at future time points using the regression equation
            List<double> predictedWeights = new List<double>();
            foreach (int futureTimePoint in futureTimePoints)
            {
                double predictedWeight = intercept + slope * futureTimePoint;
                predictedWeights.Add(predictedWeight);
            }
            return predictedWeights;
        }
    }
}
