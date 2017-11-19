using System.Collections.Generic;

namespace FranciscoWinery.Models
{
    public class ApiResult
    {
        public string TotalCount { get; set; }
        public string Duration { get; set; }
        public List<Drink> Results { get; set; }
    }

    public class SearchOptions
    {
//        public double Price { get; set; }
//        public AvailableStatus AvailableStatus { get; set; }
//        public string Category { get; set; } 
//        public string Country { get; set; } // todo: Value Object for validation      
        public string Q { get; set; } = string.Empty;
        public string SortField { get; set; } = "millesime";
        public string SortCriteria { get; set; } = "fielddescending";
        public int NumberOfResults { get; set; } = 12;
    

        public string QueryString => 
            $"{Q}&sortField={SortField}&numberOfResults={NumberOfResults}";
    }

    public enum AvailableStatus
    {
        EnSuccursale = 0,
        EnLigne,
        BientotDisponible,
        CommandeSpeciale
    }
    
    public class Drink
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public string Excerpt { get; set; }
        public RawInfo Raw { get; set; }
        
    }

    public class RawInfo
    {
        public string TpThumbnailUri { get; set; }
        public string TpDisponibilite { get; set; }
    }
}