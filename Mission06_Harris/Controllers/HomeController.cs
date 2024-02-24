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
            ViewBag.Categories = _movieContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("MovieForm", new Movie());
        }
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Movies.Add(response); // add record to database
                _movieContext.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult MovieTable() 
        {
           var forms = _movieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Year).ToList();

            return View(forms);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _movieContext.Movies
                .Single(x => x.MovieId == id);
            ViewBag.Categories = _movieContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo) 
        {
            _movieContext.Update(updatedInfo);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var recordToDelete = _movieContext.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _movieContext.Movies.Remove(movie);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }
    }
}
