﻿using System.Collections.Generic;

namespace WeatherBit.DataTransferObject
{

    public class WeatherBitResponse
    {
        public List<Datum> data { get; set; }
        public string count { get; set; }
        public string city_name { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
        public string timezone { get; set; }
    }

    public class Weather
    {
        public string icon { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Datum
    {
        public string wind_cdir { get; set; }
        public string rh { get; set; }
        public string pod { get; set; }
        public string lon { get; set; }
        public string pres { get; set; }
        public string timezone { get; set; }
        public string ob_time { get; set; }
        public string country_code { get; set; }
        public string clouds { get; set; }
        public string vis { get; set; }
        public string solar_rad { get; set; }
        public string state_code { get; set; }
        public string wind_spd { get; set; }
        public string lat { get; set; }
        public string wind_cdir_full { get; set; }
        public string slp { get; set; }
        public string datetime { get; set; }
        public string ts { get; set; }
        public string station { get; set; }
        public string h_angle { get; set; }
        public string dewpt { get; set; }
        public string uv { get; set; }
        public string dni { get; set; }
        public string wind_dir { get; set; }
        public string elev_angle { get; set; }
        public string ghi { get; set; }
        public string dhi { get; set; }
        public string precip { get; set; }
        public string city_name { get; set; }
        public Weather weather { get; set; }
        public string sunset { get; set; }
        public string temp { get; set; }
        public string sunrise { get; set; }
        public string app_temp { get; set; }
    }

  
}
