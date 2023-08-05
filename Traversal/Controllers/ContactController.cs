using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDto model)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.TInsert(new ContactUs
                {
                    Email = model.Email,
                    MessageBody = model.MessageBody,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    Name = model.Name,
                    Subject = model.Subject,
                    Status=true
                });
                return RedirectToAction("Index", "Default");
            }
            return View(model);
        }
    }
}
