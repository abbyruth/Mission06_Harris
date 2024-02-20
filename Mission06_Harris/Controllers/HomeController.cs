using Microsoft.AspNetCore.Mvc;
using Mission06_Harris.Models;
using Microsoft.EntityFrameworkCore;
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
            return View("Index");
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            _movieContext.Movies.Add(response); // add record to database
            _movieContext.SaveChanges();
            return View("Confirmation", response);
        }

    }
}
