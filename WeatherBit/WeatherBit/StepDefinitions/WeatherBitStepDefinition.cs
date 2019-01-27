using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using weatherbit.Properties;
using WeatherBit.DataTransferObject;
using WeatherBit.Framework.ApiBase;

namespace WeatherBit.StepDefinitions
{
    [Binding]
    public sealed class WeatherBitStepDefinition
    {   
        private string _queryParameter;
        private string _path;
        private WeatherBitResponse _apiResponse;
        private HttpResponseMessage _httpResponseMessage;

        
        [Given(@"Endpoint ""(.*)"" and method Get")]
        public void GivenEndpointAndMethod(string resource)
        {
            Assert.IsNotEmpty(resource,Resource.Msg_Reource_Empty);
            _path = resource;
        }

        [Given(@"The query parameter with below details added")]
        public void GivenTheQueryParameterWithBelowDetailsAdded(Table table)
        {
            var account = table.CreateInstance<QueryString>();
            _queryParameter = account.ToString();
        }

        [When(@"The request is executed")]
        public void WhenTheRequestIsExecuted()
        {
            var apiDefinition = new ApiDefinition();
            _httpResponseMessage = apiDefinition.ExecuteRestApiAsGet(_path, _queryParameter);
        }

        [Then(@"The response code should be ""(.*)""")]
        public void ThenTheResponseCodeShouldBe(int statusCode)
        {
            _httpResponseMessage.EnsureSuccessStatusCode();
            Assert.True(((int)_httpResponseMessage.StatusCode == statusCode),Resource.Msg_Api_Status_Code,statusCode,(int) _httpResponseMessage.StatusCode);
            _apiResponse = _httpResponseMessage.Content.ReadAsAsync<WeatherBitResponse>().Result;
        }

        [Then(@"The current weather data result should should contain the below values")]
        public void ThenTheResultShouldShouldContainTheBelowValues(Table table)
        {
            var testAssert = table.CreateInstance<TestAssertDto>();
            var resultItem = _apiResponse != null && _apiResponse.data.Any(s => s.city_name == testAssert.City_Name
                                                                                && s.country_code == testAssert.Country_code);

            Assert.True(resultItem, string.Format(Resource.Err_Api_Failure, testAssert.City_Name, testAssert.Country_code, JsonConvert.SerializeObject(_apiResponse), Formatting.Indented));

        }

        [Then(@"The 3 hour forecast data result should should contain the below values")]
        public void ThenTheHourForecastDataResultShouldShouldContainTheBelowValues(Table table)
        {
            var testAssert = table.CreateInstance<TestAssertDto>();
            var resultItem = _apiResponse != null && (_apiResponse.country_code != testAssert.Country_code ||
                                                      _apiResponse.city_name != testAssert.City_Name);
            Assert.False(resultItem, string.Format(Resource.Err_Api_Failure, testAssert.City_Name, testAssert.Country_code, JsonConvert.SerializeObject(_apiResponse), Formatting.Indented));

        }

    }
}
