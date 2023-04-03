using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Data;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
        private readonly ApplicationDBContext _context;

        public CustomersController(ApplicationDBContext context)
        {
            _context = context;

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Customer 
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            IEnumerable<Customer> Customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(Customers);
        }

        [Route("Customers/Details/{id}")]
        public IActionResult Details(int id)
        {
            Customer found = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            if (found == null)
                return NotFound();
            else
                return View(found);

        }

    }
}

