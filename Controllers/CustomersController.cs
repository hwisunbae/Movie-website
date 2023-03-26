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
            base.Dispose(disposing);
        }

        // Customer 
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            IEnumerable<Customer> Customers = _context.Customers.ToList();
            return View(Customers);
        }

        [Route("Customers/Details/{id}")]
        public IActionResult Details(int id)
        {
            Customer found = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (found == null)
                return NotFound();
            else
                return View(found);

        }

        //public IActionResult New(int id)
        //{
        //    NewCustomerViewModel viewModel = new NewCustomerViewModel
        //    {
        //        MembershipTypes = this.membershipTypes
        //    };
            
        //    return View(viewModel);

        //}


    }
}

