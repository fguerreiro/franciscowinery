using System.Collections.Generic;

namespace FranciscoWinery.Models
{
    public interface IApiResult
    {
        int TotalCount { get; set; }
        int Duration { get; set; }
        IEnumerable<Drink> Results { get; set; }
    }
}