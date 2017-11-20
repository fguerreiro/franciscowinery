using FranciscoWinery.Controllers;
using FranciscoWinery.Models;
using NUnit.Framework;
using System.Linq;
using System.Web.Mvc;
using Ploeh.AutoFixture;
using Moq;
using System.Web;
using System.Web.Routing;

namespace FranciscoWineryTests
{
    [TestFixture]
    public class HomeTests
    {
        private HomeController _sut;
        private SearchOptions _searchOptions;

        [SetUp]
        public void Setup()
        {
            var request = new Mock<HttpRequestBase>();
            request.SetupGet(x => x.Headers).Returns(
                new System.Net.WebHeaderCollection());
            
            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            
            _sut = new HomeController(new Mock<ApiResultFetcher>().Object);
            _sut.ControllerContext = new ControllerContext(context.Object, new RouteData(), _sut);
            
            _searchOptions = new SearchOptions()
                {
                    Q = "ale"
                };
        }
        
        [Test]
        public void Index_ShouldReturnNoResult()
        {
            var result = _sut.Index() as ViewResult;

            Assert.Multiple(() =>
            {
                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Model);
                Assert.That(result.Model is NoResult);
            });
        }
        
        [Test]
        public void Index_SearchADrink_ShouldReturnApiResult()
        {
            var result = _sut.Search(_searchOptions) as ViewResult;

            Assert.That(result.Model is ApiResult);
        }
        
        [Test]
        public void Index_SearchAnAle_ShouldHaveAnAle()
        {
            var viewResult = _sut.Search(_searchOptions) as ViewResult;
            var resultModel = viewResult.Model as ApiResult;

            var aleUri = resultModel.Results.First().Uri;
            
            // todo: this test is fragile, if the route Uri changes, test will break
            Assert.That(aleUri.Contains("biere-ale"));
        }
        
        [Test]
        public void Index_SearchADrink_ShouldReturnMoreThanOneItem()
        {
            var viewResult = _sut.Search(_searchOptions) as ViewResult;
            var resultModel = viewResult.Model as ApiResult;
            
            Assert.That(resultModel.TotalCount > 0);
        }
    }
}