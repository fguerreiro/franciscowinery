using System.Web.Mvc;
using FranciscoWinery.Models;

namespace FranciscoWinery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiResultFetcher _apiResultFetcher;

        public HomeController(IApiResultFetcher apiResultFetcher)
        {
            _apiResultFetcher = apiResultFetcher;
        }
        public ActionResult Index()
        {
            var emptyResult = new NoResult();
            return View(emptyResult);
        }

        public ActionResult About()
        {
            ViewBag.Message = "This was a pet project to play with the Coveo search API.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "francisco.guerreiro.jr@gmail.com";

            return View();
        }
        
        public ActionResult Search(SearchOptions search)
        { 
            ApiResult result = _apiResultFetcher.GetApiResultAsync(search.QueryString);
            
            if (Request.IsAjaxRequest())
            {
                return PartialView("_SearchResult", result);
            }
            
            return View("Index", result);
        }    
        
    }
}