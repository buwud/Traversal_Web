using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	public class ApiMovieController : Controller
	{
		
		public async Task<IActionResult> Index()
		{
            List<ApiMovieViewModel> _apiMovies = new List<ApiMovieViewModel>();
            var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies1.p.rapidapi.com/"),
				Headers =
	{
		{ "X-RapidAPI-Key", "60a34c30e5msh48eebb101f4d624p1f8af9jsn8f9ae77c7d41" },
		{ "X-RapidAPI-Host", "imdb-top-100-movies1.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				_apiMovies = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);

				return View(_apiMovies);
			}

		}
	}
}
