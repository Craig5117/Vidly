using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "John Smith", Id = 1 },
                new Customer { Name = "Mary Williams", Id = 2 }
            };
        // GET: Customers
        public ActionResult Index()
        {

            var viewModel = new CustomersViewModel()
            {
                Customers = customers
            };
        
            return View(viewModel);
        }
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Customers");
                
            }
            Customer customer = new Customer();


            if (customers.Any(c => c.Id == id))
            {
                customer = customers.Find(c => c.Id == id);
            }
            else
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}