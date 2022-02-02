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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new Assignment3.Models.ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            foreach(var person in   db.People.ToList()) {
                if(person is Employee)
                    employees.Add(person as Employee);
            }


            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = (Employee) db.People.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employeeServiceViewModel = new EmployeeServiceViewModel {
                Employee = db.Employees.Include(i => i.Services).First(i => i.Id == id)
            };

            if(employeeServiceViewModel.Employee == null)
                return HttpNotFound();

            var allServicesList = db.Services.ToList();
            employeeServiceViewModel.AllServices = allServicesList.Select(o => new SelectListItem {
                Text = o.Name,
                Value = o.Id.ToString()
            });
            return View(employeeServiceViewModel);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection data, [Bind(Include = "Id, Name, Address, Salary")] Employee employee)
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
                    nextService.Employees.Add(employee);
                    db.Entry(nextService).State = EntityState.Modified;
                    employee.Services.Add(nextService);
                }
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
               
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = (Employee) db.People.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = (Employee) db.People.Find(id);
            db.People.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("DeleteService")]
        public ActionResult DeleteService(int employeeId, int serviceId)
        {
            Console.WriteLine(employeeId);

            Employee employee = (Employee)db.People.Find(employeeId);
            Service service = (Service)db.Services.Find(serviceId);
            employee.Services.Remove(service);
            service.Employees.Remove(employee);
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
