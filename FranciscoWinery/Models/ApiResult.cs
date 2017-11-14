using System.Collections.Generic;

namespace FranciscoWinery.Models
{
    public class ApiResult
    {
        public string TotalCount { get; set; }
        public string Duration { get; set; }
        public List<Drink> Results { get; set; }
    }

    public class Drink
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public string Excerpt { get; set; }
    }
}