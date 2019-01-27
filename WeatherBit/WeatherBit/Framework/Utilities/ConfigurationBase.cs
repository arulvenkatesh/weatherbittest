using System.Configuration;

namespace WeatherBit.Framework.Utilities
{
    class ConfigurationBase
    {
       public static string ApiUrl => ConfigurationManager.AppSettings[Constants.ApiUrl];

       public static string ApiKey => ConfigurationManager.AppSettings[Constants.ApiKey];

       public static string ApiVersion => ConfigurationManager.AppSettings[Constants.ApiVersion];
    }
}
