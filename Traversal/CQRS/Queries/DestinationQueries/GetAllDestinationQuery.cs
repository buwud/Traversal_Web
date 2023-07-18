using MediatR;
using Traversal.CQRS.Results.GuideResults;

namespace Traversal.CQRS.Queries.DestinationQueries
{
    public class GetAllDestinationQuery:IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
