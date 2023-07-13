using DataAccessLayer.Concrete;
using Traversal.CQRS.Queries.DestinationQueries;
using Traversal.CQRS.Results.DestinationResults;

namespace Traversal.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            this._context = context;
        }

        public GetDestinationByIdQueryResults Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIdQueryResults
            {
                desId = values.DestinationID,
                city = values.City,
                daynight = values.StayTime
            };
        }
    }
}
