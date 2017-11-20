using System.Collections.Generic;

namespace FranciscoWinery.Models
{
    public class NoResult : IApiResult
    {
        public int TotalCount { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public IEnumerable<Drink> Results { get; set; } 
            = new List<NullDrink>();
    }
}