using WeatherBit.Framework.Utilities;

namespace WeatherBit.DataTransferObject
{
    class QueryString
    {
        string _query = "Key="+ConfigurationBase.ApiKey;
        public string City;
        public string Country;
        public string Postal_Code;

        public override string ToString()
        {   
            IgnoreNull("City",City);
            IgnoreNull("Country", Country);
            IgnoreNull("Postal_Code", Postal_Code);
            return _query;
        }

        private void IgnoreNull(string param,string value)
        {
            if (!string.IsNullOrEmpty(param) && !string.IsNullOrEmpty(value) )
            {
                _query = _query + "&" + param + "=" + value;
            }
        }
    }
}
