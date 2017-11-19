using System;
namespace FranciscoDrinksSAQ.Security
{
    public static class ApiToken
    {
        public static string Token = "058c85fd-3c79-42a3-9236-b83d35588103";

        //&q=Bi%C3%A8re%20rousse
        //https://cloudplatform.coveo.com/rest/search?access_token=058c85fd-3c79-42a3-9236-b83d35588103&q=Bi%C3%A8re%20rousse
        public static string Url = 
            $"https://cloudplatform.coveo.com/rest/search?access_token={Token}";
    }
}
