using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalAPI.DAL.Context;
using TraversalAPI.DAL.Entities;

namespace TraversalAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private GuestContext context;
        public GuestController() 
        {
            context = new GuestContext();
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var values = context.Guests.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult GuestAdd(Guest g) 
        {
                context.Add(g);
                context.SaveChanges();
                return Ok();
        }
        [HttpGet("{id}")]//gey by id
        public IActionResult GuestGet(int id)
        {
            var values = context.Guests.Find(id);
            if(values == null)
                return NotFound();
            else
                return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var values=context.Guests.Find(id);
            if (values == null)
                return NotFound();
            else
            {
                context.Remove(values);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult PutGuest(Guest g)
        {
            var values = context.Find<Guest>(g.GuestID);
            if (values== null)
                return NotFound();
            else
            {
                values.Name = g.Name;
                values.Surname = g.Surname;
                values.City= g.City;
                values.Country=g.Country;
                values.Mail = g.Mail;
                context.Update(values);
                context.SaveChanges();
                return Ok();
            }
        }

    }
}
