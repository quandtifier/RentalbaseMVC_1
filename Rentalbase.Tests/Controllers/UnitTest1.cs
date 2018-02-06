using System;
using System.Net;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rentalbase.Controllers;
using Rentalbase.Models;

namespace Rentalbase.Tests.Controllers
{
    [TestClass]
    public class PropertyControllerTest
    {
        [TestMethod]
        public void TestDetails()
        {
            PropertyController controller = new PropertyController();
            ViewResult viewResult = controller.Details(1) as ViewResult;
            Property result = (Property)viewResult.ViewData.Model;

            Property property = new Property();
            property.ID = 1;
            property.Street = "38 Galvin Road";
            property.City = "Seattle";
            property.State = "WA";
            property.Zip = 98181;
            property.Value = 5000;
            property.Description = "Need something here";

            Assert.AreEqual(property.Street, result.Street);

        }
    }
}
