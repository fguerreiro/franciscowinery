using System;
using FranciscoWinery.Controllers;
using NUnit.Framework;

namespace FranciscoWineryTests
{
    [TestFixture]
    public class HomeTests
    {
        private HomeController _sut;
        // test: Given a no search, should return a NoResult
        
        // test: Given an invalid search, return proper helpful page
        
        // test: Given a valid search, return something relevant

        [SetUp]
        public void Setup()
        {
            _sut = new HomeController();
        }
        
        [Test]
        public void Index_ShouldReturnNoResult()
        {
            Assert.True(true);
        }
    }
}