using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Traversal.CQRS.Queries.DestinationQueries;
using Traversal.CQRS.Results.DestinationResults;

namespace Traversal.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResults> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResults()
            {
                id = x.DestinationID,
                capacity = x.Capacity,
                city = x.City,
                duration = x.StayTime,
                price=(double)x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
