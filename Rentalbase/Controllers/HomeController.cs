using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentalbase.DAL;
using Rentalbase.ViewModels;

namespace Rentalbase.Controllers
{
    public class HomeController : Controller
    {
        private RBaseContext db = new RBaseContext();

        public ActionResult Index()
        {
            return View();
        }

        // LINQ groups the properties by city then calculates the number of props/city
        // then stores the results in a collection PropertyCityGroup
        public ActionResult About()
        {
            IQueryable<PropertyCityGroup> data =
                from property in db.Properties
                group property by property.City into propertyGroup
                select new PropertyCityGroup()
                {
                    City = propertyGroup.Key,
                    PropertyCount = propertyGroup.Count()
                };

            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}