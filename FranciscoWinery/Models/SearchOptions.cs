namespace FranciscoWinery.Models
{
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
}