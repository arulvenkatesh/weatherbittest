using System;
using System.Net.Http;
using NUnit.Framework;
using weatherbit.Properties;
using WeatherBit.Framework.Utilities;

namespace WeatherBit.Framework.ApiBase
{
    class ApiDefinition
    {
        private readonly UriBuilder _apiUri = new UriBuilder(ConfigurationBase.ApiUrl);

        public HttpResponseMessage ExecuteRestApiAsGet(string path,string queryParam)
        {
            using (var httpClient = new HttpClient())
            {
                _apiUri.Path = ConfigurationBase.ApiVersion+path;
                _apiUri.Query = queryParam;
                try
                {
                    var responseContent = httpClient.GetAsync(_apiUri.Uri);
                    return responseContent.Result;
                }
                catch (Exception ex)
                {
                    Assert.Fail(Resource.Err_Api_Exception, ex.Message, ex.Source);
                    throw;
                }
            }
        }
    }
}
