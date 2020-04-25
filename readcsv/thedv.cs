using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readcsv
{




    public class Rootobject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string vendor { get; set; }
        public Location location { get; set; }
        public int pollutionLevel { get; set; }
        public Address address { get; set; }

        public Currentmeasurements currentMeasurements { get; set; }
        public Forecast[] forecast { get; set; }
        public History[] history { get; set; }

    }

    public class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
    }

    public class Address
    {
        public string streetNumber { get; set; }
        public string route { get; set; }
        public string locality { get; set; }
        public string country { get; set; }
    }

    // measurement

    public class Currentmeasurements
    {
        public int airQualityIndex { get; set; }
        public int humidity { get; set; }
        public string measurementTime { get; set; }
        public int pm1 { get; set; }
        public int pm10 { get; set; }
        public int pm25 { get; set; }
        public int pollutionLevel { get; set; }
        public int pressure { get; set; }
        public int temperature { get; set; }
        public int windDirection { get; set; }
        public int windSpeed { get; set; }
    }

    public class Forecast
    {
        public string fromDateTime { get; set; }
        public Measurements measurements { get; set; }
        public string tillDateTime { get; set; }
    }

    public class Measurements
    {
        public int airQualityIndex { get; set; }
        public int humidity { get; set; }
        public string measurementTime { get; set; }
        public int pm1 { get; set; }
        public int pm10 { get; set; }
        public int pm25 { get; set; }
        public int pollutionLevel { get; set; }
        public int pressure { get; set; }
        public int temperature { get; set; }
        public int windDirection { get; set; }
        public int windSpeed { get; set; }
    }

    public class History
    {
        public string fromDateTime { get; set; }
        public Measurements1 measurements { get; set; }
        public string tillDateTime { get; set; }
    }

    public class Measurements1
    {
        public int airQualityIndex { get; set; }
        public int humidity { get; set; }
        public string measurementTime { get; set; }
        public int pm1 { get; set; }
        public int pm10 { get; set; }
        public int pm25 { get; set; }
        public int pollutionLevel { get; set; }
        public int pressure { get; set; }
        public int temperature { get; set; }
        public int windDirection { get; set; }
        public int windSpeed { get; set; }
    }

}
