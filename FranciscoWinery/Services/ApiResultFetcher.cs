using System.Net.Http;
using FranciscoDrinksSAQ.Security;
using Newtonsoft.Json;

namespace FranciscoWinery.Models
{
    public interface IApiResultFetcher
    {
        ApiResult GetApiResultAsync(string q);
    }

    public class ApiResultFetcher : IApiResultFetcher
    {
        public ApiResult GetApiResultAsync(string q)
        {
            ApiResult apiResult = null;

            var path = ApiToken.Url + "&q=" + q;
            HttpResponseMessage response = ApiClient.Client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                apiResult = JsonConvert.DeserializeObject<ApiResult>(json);
            }
            return apiResult;
        }
    }
}