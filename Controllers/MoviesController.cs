using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MoviesController(ApplicationDBContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Edit(int id)
        {
            return Content("id =" + id);
        }

        // Movies 
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            IEnumerable<Movie> movies = _context.Movies.ToList();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            Movie found = _context.Movies.FirstOrDefault(c => c.Id == id);
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