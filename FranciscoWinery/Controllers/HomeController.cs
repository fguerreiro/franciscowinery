using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using FranciscoDrinksSAQ.Security;
using FranciscoWinery.Models;
using Newtonsoft.Json;
using Fetcher = FranciscoWinery.Models.ApiResultFetcher;

namespace FranciscoWinery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
            ApiResult result = Fetcher.GetApiResultAsync(search.QueryString);
            
            if (Request.IsAjaxRequest())
            {
                return PartialView("_SearchResult", result);
            }
            
            return View("Index", result);
        }    
    }
}