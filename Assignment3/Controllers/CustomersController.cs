using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment3.Models;
using Assignment3.ViewModels;

namespace Assignment3.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new Assignment3.Models.ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            foreach(var person in db.People.ToList()) {
                if(person is Customer)
                    customers.Add(person as Customer);
            }


            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = (Customer) db.People.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customerServiceViewModel = new CustomerServiceViewModel
            {
                Customer = db.Customers.Include(i => i.Services).First(i => i.Id == id)
            };
            if (customerServiceViewModel.Customer == null)
            {
                return HttpNotFound();
            }

            var allServicesList = db.Services.ToList();
            customerServiceViewModel.AllServices = allServicesList.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            });
            return View(customerServiceViewModel);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection data, [Bind(Include = "Id,Name,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {

                Console.WriteLine(data.Get("SelectedServices"));
                var test = data.Get("SelectedServices");
                var services = test.Split(',');
                ICollection<Service> serviceList = new HashSet<Service>();
                foreach (String service in services)
                {
                    int parsedInt = Int32.Parse(service);
                    Service nextService = db.Services.Find(parsedInt);
                    nextService.Customers.Add(customer);
                    db.Entry(nextService).State = EntityState.Modified;
                    customer.Services.Add(nextService);
                }
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = (Customer) db.People.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = (Customer) db.People.Find(id);
            db.People.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("DeleteService")]
        public ActionResult DeleteService(int customerId, int serviceId)
        {
            Console.WriteLine(customerId);

            Customer customer = (Customer)db.People.Find(customerId);
            Service service = (Service)db.Services.Find(serviceId);
            customer.Services.Remove(service);
            service.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
