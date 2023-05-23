using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using System.Text;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/GuestApi")]
    public class GuestApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GuestApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responceMessage = await client.GetAsync("http://localhost:61377/api/Guest");
            if (responceMessage.IsSuccessStatusCode)
            {
                var jsonData = await responceMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GuestApiViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("AddGuest")]
        public IActionResult AddGuest()
        {
            return View();
        }
        [HttpPost]
        [Route("AddGuest")]
        public async Task<IActionResult> AddGuest(GuestApiViewModel m)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(m);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:61377/api/Guest", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteGuest/{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:61377/api/Guest/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Route("EditGuest/{id}")]
        public async Task<IActionResult> EditGuest(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:61377/api/Guest/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<GuestApiViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("EditGuest/{id}")]
        public async Task<IActionResult> EditGuest(GuestApiViewModel m)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(m);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("http://localhost:61377/api/Guest", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
