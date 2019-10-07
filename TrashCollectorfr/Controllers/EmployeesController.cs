using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollectorfr.Models;

namespace TrashCollectorfr.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var Id = User.Identity.GetUserId();
            Employee employee = db.Employees.Where(e => e.ApplicationId == Id).FirstOrDefault();
            var dayOfWeek = DateTime.Today.DayOfWeek.ToString();
            // query days table using 'dayOfWeek'
            var today = db.Customers.Where(c => c.Day.DayOfWeek == dayOfWeek);
            var customers = db.Customers.Where(c => c.Zipcode == employee.Zipcode && (c.ExtraDay == DateTime.Today.DayOfWeek.ToString() || c.Day.DayOfWeek == dayOfWeek));
            //customers = customers.Where(they are NOT currently suspended); COME BACK TO
            var customersExtra = db.Customers.Where(c => c.ExtraDay == DateTime.Today.DayOfWeek.ToString());

           // ViewBag.Name = new SelectList(db.Days.Where(u => !u.DayOfWeek.Contains("Admin")).ToList(), "Id", "DayOfWeek");
            return View(customers);
        }

       

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Zipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", new{Id=employee.Id});
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
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Zipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
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
            Employee employee = db.Employees.Find(id);
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
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sort(int? Id)
        {
            DayOfWeek day = DayOfWeek.Monday;

            switch (Id)
            {
                case 1:
                    day = DayOfWeek.Monday;
                    break;
                case 2:
                    day = DayOfWeek.Tuesday;
                    break;
                case 3:
                    day = DayOfWeek.Wednesday;
                    break;
                case 4:
                    day = DayOfWeek.Thursday;
                    break;
                case 5:
                    day = DayOfWeek.Friday;
                    break;
                case 6:
                    day = DayOfWeek.Saturday;
                    break;
                case 7:
                    day = DayOfWeek.Sunday;
                    break;
                default: 
                    break;                 
            }
            Employee employee = db.Employees.Where(e => e.Id == Id).FirstOrDefault(); 
            var dayOfWeek = DateTime.Today.DayOfWeek.ToString();
            //var today = db.Customers.Where(c => c.Day.DayOfWeek == dayOfWeek);
            var customers = db.Customers.Where(c => c.Zipcode == employee.Zipcode); //&& (c.ExtraDay == DateTime.Today.DayOfWeek.ToString() || c.Day.DayOfWeek == dayOfWeek));
            var currentDay = customers.Where(c => c.DayId == Id);
            return View("Index",currentDay);
        }

        public ActionResult Balance(int? Id)
        {
            var currentcustomer = db.Customers.Find(Id);
            currentcustomer.Balance = 20;
            db.SaveChanges();
            return View("Confirm");
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
