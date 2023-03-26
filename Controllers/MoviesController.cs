using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> movies;
        private RandomMovieViewModel viewModel;

        public MoviesController()
        {
            this.movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Wall-e"},
                new Movie {Id = 3, Name = "Dragon"}
            };

            this.viewModel = new RandomMovieViewModel
            {
                Movies = this.movies
            };
        }
        public IActionResult Edit(int id)
        {
            return Content("id =" + id);
        }

        // Movies 
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            return View(this.viewModel);
        }

        public IActionResult Details(int id)
        {
            Movie found = this.viewModel.Movies.FirstOrDefault(c => c.Id == id);
            if (found == null)
                return NotFound();
            else
                return View(found);

        }

        [Route("movies/released/{year}/{month:regex(\\d{{2}}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}