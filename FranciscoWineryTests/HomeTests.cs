using System;
using FranciscoWinery.Controllers;
using FranciscoWinery.Models;
using NUnit.Framework;
using System.Linq;
using System.Web.Mvc;

namespace FranciscoWineryTests
{
    [TestFixture]
    public class HomeTests
    {
        private HomeController _sut;
        
        // test: Given an invalid search, return proper helpful page
        
        // test: Given a valid search, return something relevant

        [SetUp]
        public void Setup()
        {
            _sut = new HomeController();

        }
        
        // test: Given a no search, should return a NoResult
        [Test]
        public void Index_ShouldReturnNoResult()
        {
            var result = _sut.Index() as ViewResult;

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Model); // add additional checks on the Model
                Assert.That(result.Model is NoResult);
            });
        }
    }
}