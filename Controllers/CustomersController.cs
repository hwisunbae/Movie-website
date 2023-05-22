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

        public IActionResult New()
        {
            IEnumerable<MembershipType> membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.First(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedNewsletter = customer.IsSubscribedNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Edit(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}

