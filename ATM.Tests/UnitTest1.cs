using System;
using System.Web.Mvc;
using ATM.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATM.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FooActionRetrunsAboutView()
        {
            var homeController = new HomeController();
            var result = homeController.Foo() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }

        [TestMethod]
        public void ContactFormSaysThanks()
        {
            var homeController = new HomeController();
            var result = homeController.Contact("Your contact page.") as ViewResult;
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }
    }
}
