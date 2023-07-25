using MediatR;

namespace fitness_tracker_service.Application.Queries
{
    public class GetPredictionsQuery : IRequest<List<double>>
    {
    }
}
