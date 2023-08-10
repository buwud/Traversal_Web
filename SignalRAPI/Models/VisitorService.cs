using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRAPI.DAL;
using SignalRAPI.Hubs;

namespace SignalRAPI.Models
{

    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }
        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallVisitorList", GetVisitorChartList);
        }

        public List<VisitorChart> GetVisitorChartList() 
        {
            List<VisitorChart> visitorCharts=new List<VisitorChart>();
            using( var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select * from crossTab ('select dateTime,ecity,cityVisitorCount from Visitors order by 1,2') as ct(dateTime timestamp, City1 int, City2 int, City3 int, City4 int, City5 int)";
                command.CommandType=System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using( var reader= command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChart = new VisitorChart();
                        visitorChart.Date=reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(0, 5).ToList().ForEach(x =>
                        {
                            visitorChart.Counters.Add(reader.GetInt32(x));
                        });
                        visitorCharts.Add(visitorChart); 
                    }
                }
                _context.Database.CloseConnection();
                return visitorCharts;

            }
        }
    }
}
