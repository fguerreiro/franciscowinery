using System.Collections.Generic;

namespace FranciscoWinery.Models
{
    public class ApiResult : IApiResult
    {
        public int TotalCount { get; set; }
        public int Duration { get; set; }
        public IEnumerable<Drink> Results { get; set; } = new List<Drink>();
    }
}