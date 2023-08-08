using Microsoft.AspNetCore.Mvc;
using SignalRAPI.DAL;
using SignalRAPI.Models;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;

        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        [HttpGet]
        public IActionResult CreateVisitor()
        {
            Random rand=new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (Ecity item in Enum.GetValues(typeof(Ecity)))
                {
                    var newVisitor = new Visitor
                    {
                        ecity = item,
                        cityVisitorCount = rand.Next(100, 4000),
                        dateTime = DateTime.UtcNow.AddDays(x)
                    };
                    _visitorService.SaveVisitor(newVisitor).Wait();
                    Thread.Sleep(1000);
                }
            });
            return Ok();
        }
    }
}
