using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Rentalbase.DAL;
using Rentalbase.Models;
using System.Data.Entity.Infrastructure;

namespace Rentalbase.Controllers
{
    public class PropertyController : Controller
    {
        private RBaseContext db = new RBaseContext();

        // GET: Property
        // initially all params are null until the user selects a filter or inputs into the searchbox
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            // gather input for whether a sort-by-col filter has been requested
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.CitySortParm = sortOrder == "city" ? "city_desc" : "city";
            
            // everytime the user searches, display results starting at page 1
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            // provides the view with the current filter string
            ViewBag.CurrentFilter = searchString;
            // linq expression selects all properties in db
            var properties = from p in db.Properties
                             select p;
            // if there is search form input then find which properties fit the searchString
            if (!String.IsNullOrEmpty(searchString))
            {
                properties = properties.Where(p => p.Street.Contains(searchString)
                                            || p.City.Contains(searchString));
            }
            // order by sort-by-col filter
            switch (sortOrder)
            {
                case "city":
                    properties = properties.OrderBy(p => p.City);
                    break;
                case "city_desc":
                    properties = properties.OrderByDescending(p => p.City);
                    break;
                case "id_desc":
                    properties = properties.OrderByDescending(p => p.ID);
                    break;
                default:
                    properties = properties.OrderBy(p => p.ID);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);//null-coalescing: if page is null return 1
            return View(properties.ToPagedList(pageNumber, pageSize));
        }

        // GET: Property/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Property/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Street,City,State,Zip,Value,Description")] Property property)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    db.Properties.Add(property);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                ModelState.AddModelError("", "Unable to save changes");
            }
            return View(property);
        }

        // GET: Property/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Property/Edit/5
        // The practices here implement a security best practice for overposting.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var propertyToUpdate = db.Properties.Find(id);
            if (TryUpdateModel(propertyToUpdate, "",
                new string[] { "Street", "City", "State", "Zip", "Value", "Description"}))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /*dex*/)
                {
                    // uncomment dex for error logging
                    ModelState.AddModelError("", "Unable to save changes");
                }
            }
            return View(propertyToUpdate);

        }

        // GET: Property/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. You don't want homeless tenants do you?!?";
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Property/Delete/5
        // on failure this method will call the GET in order to give the user the option to try again
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Property property = db.Properties.Find(id);
                db.Properties.Remove(property);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                //uncomment dex for error logging
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
