namespace FranciscoWinery.Models
{
    public class NullDrink : Drink
    {
        public string Title = "Empty";
        public string Uri = "Empty";
        public string Excerpt = "Empty";
        public RawInfo Raw = new NullRawInfo();
    }
}