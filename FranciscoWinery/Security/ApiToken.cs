using System;
namespace FranciscoDrinksSAQ.Security
{
    public static class ApiToken
    {
        private static string Token = "058c85fd-3c79-42a3-9236-b83d35588103";

        public static string Url = 
            $"https://cloudplatform.coveo.com/rest/search?access_token={Token}";
    }
}
