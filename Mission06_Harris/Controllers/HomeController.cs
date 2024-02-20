using Microsoft.AspNetCore.Mvc;
using Mission06_Harris.Models;
using System.Diagnostics;

namespace Mission06_Harris.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _movieContext;
        public HomeController(MoviesContext temp)
        {
            _movieContext = temp;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            return View(response);
        }

    }
}
