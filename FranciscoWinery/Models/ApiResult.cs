using System.Collections.Generic;

namespace FranciscoWinery.Models
{
    public interface IApiResult
    {
        int TotalCount { get; set; }
        int Duration { get; set; }
        IEnumerable<Drink> Results { get; set; }
    }

    public class NoResult : IApiResult
    {
        public int TotalCount { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public IEnumerable<Drink> Results { get; set; } 
            = new List<NullDrink>();
    }

    public class ApiResult : IApiResult
    {
        public int TotalCount { get; set; }
        public int Duration { get; set; }
        public IEnumerable<Drink> Results { get; set; } = new List<Drink>();
    }

    public class SearchOptions
    {
        public string Q { get; set; } = string.Empty;
        public string SortField { get; set; } = "millesime";
        public string SortCriteria { get; set; } = "fielddescending";
        public int NumberOfResults { get; set; } = 12;
    
        public string QueryString => 
            $"{Q}&numberOfResults={NumberOfResults}{GetSortCriteria()}";

        private string GetSortCriteria()
        {
            if (SortField == "tpprixnum")
            {
                return $"&sortField={SortField}&sortCriteria={SortCriteria}";
            }
            return "";
        }
    }

    public enum AvailableStatus
    {
        EnSuccursale = 0,
        EnLigne,
        BientotDisponible,
        CommandeSpeciale
    }

    
    public class NullDrink : Drink
    {
        public string Title = "Empty";
        public string Uri = "Empty";
        public string Excerpt = "Empty";
        public RawInfo Raw = new NullRawInfo();
    }
    
    public class Drink
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public string Excerpt { get; set; }
        public RawInfo Raw { get; set; }
        
    }

    public class NullRawInfo : RawInfo
    {
        public string TpThumbnailUri = "Empty";
        public string TpDisponibilite = "Empty";
    }
    
    public class RawInfo
    {
        public string TpThumbnailUri { get; set; }
        public string TpDisponibilite { get; set; }
    }
}