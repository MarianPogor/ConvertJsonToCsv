using ChoETL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCitizenApp
{


    public class Location
    {
        public string city { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }

    public class Owner
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string username { get; set; }
        public string avatar { get; set; }
        public string url { get; set; }
        public DateTime joined_at { get; set; }
        public Location location { get; set; }
        public int[] device_ids { get; set; }
    }

    public class Location2
    {
        public object ip { get; set; }
        public string exposure { get; set; }
        public int? elevation { get; set; }
        public float? latitude { get; set; }
        public float? location_longitude { get; set; }
        public string geohash { get; set; }
        public string city { get; set; }
        public string country_code { get; set; }
        public string country { get; set; }
    }

    public class Sensor
    {
        public int id { get; set; }
        public string ancestry { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int measurement_id { get; set; }
        public string uuid { get; set; }
        public float? value { get; set; }
        public float? raw_value { get; set; }
        public float? prev_value { get; set; }
        public float? prev_raw_value { get; set; }
    }

    public class Data
    {
        public DateTime? recorded_at { get; set; }
        public DateTime? added_at { get; set; }
        public Location2 location { get; set; }
        public Sensor[] sensors { get; set; }
    }

    public class Kit
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }


    [DefaultValue("Device")]
    public class Device
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public string[] system_tags { get; set; }
        public string[] user_tags { get; set; }
        public DateTime? last_reading_at { get; set; }
        public DateTime added_at { get; set; }
        public DateTime updated_at { get; set; }
        public string mac_address { get; set; }
        public Owner owner { get; set; }
        public Data data { get; set; }
        public Kit kit { get; set; }
        public IEnumerable<Location> Location { get; internal set; }
    }




}
