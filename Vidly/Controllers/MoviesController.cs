using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> movies = new List<Movie>
            {
                new Movie { Name = "Shrek", Id = 1 },
                new Movie { Name = "Wall-e", Id = 2 }
            };
        // GET: Movies
        public ActionResult Index()
        {
            var viewModel = new MoviesViewModel()
            {
                Movies = movies
            };

            return View(viewModel);
        }
        public ActionResult Random()
        {
            // in this example, data is passed into the view as an argument
            // this is best
            var movie = new Movie() { Name = "Shrek!" };
            // every controller has a property called ViewData of the type ViewDataDictionary
            // this method is not ideal as it looks messy in the view
            // also the use of the magic string can create problems later on if changes are made
            // ViewData["Movie"] = movie;
            // requires @ViewData["Movie"] in the view html to acces the data
            // ViewBag.Movie = movie; is an alternative approach Microsoft introduced
            // It is also not ideal it has the same issue as the magic string
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
            // return Content("Hello World!");
            // return HttpNotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }
        // custom route enabled by routes.MapMvcAttributeRoutes(); in AppStart/RouteConfig
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]

        public ActionResult ByReleaseDate(int year, byte month)
      {
          return Content(year + "/" + month);
      }
          
    }
}