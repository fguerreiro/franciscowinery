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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Search(SearchOptions search)
        { 
            ApiResult result = Fetcher.GetApiResultAsync(search.QueryString);
            
            return View("List", result);
        }
        
    }
}

public class SearchOptions
{
    public string Q { get; set; } = string.Empty;
    public string SortField { get; set; } = "millesime";
    public string SortCriteria { get; set; } = "fielddescending";
    public int NumberOfResults { get; set; } = 12;
    

    public string QueryString => 
        $"{Q}&sortField={SortField}&numberOfResults={NumberOfResults}&sortCriteria={SortCriteria}";
}

public static class Helpers
{
    public static bool HasValue(this string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}