using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReviews.Models;
using MovieReviews.Controllers;

namespace MovieReviews.Tests.MovieReviews.UI.Tests
{
    [TestClass]
    public class HomeControllerTests
    {        
        [TestMethod]
        public void TestForIndexAction()
        {
            //Arrange
            HomeController home = new HomeController();            

            //Act
            ViewResult result = home.Index() as ViewResult;

            //Assert
            Assert.AreEqual("", result.ViewName);
        }
    }
}
