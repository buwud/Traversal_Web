using Microsoft.AspNetCore.SignalR;
using SignalRAPI.Models;

namespace SignalRAPI.Hubs
{
    public class VisitorHub:Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        public async Task getVisitorList()
        {
            await Clients.All.SendAsync("CallVisitList", "aaa");
        }
    }
}
