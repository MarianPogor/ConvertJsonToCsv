//using ChoETL;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

using ChoETL;
using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



using System.Dynamic;
using Microsoft.Win32;

namespace readcsv
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var hasValues = true;

            List<Rootobject> obj = new List<Rootobject>();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 2, 30);
            var json = "";


            var url = string.Format("https://airapi.airly.eu/v1/sensorsWithWios/current?southwestLat=49&southwestLong=22&northeastLat=54&northeastLong=18&apikey=TsTYb8xiNEI5c4Uc92GiFofG4DnP1W0l");
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {

                var temp = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("response ");
                if (temp == "[]")
                {
                    hasValues = false;
                    Console.WriteLine("The list is empty");
                }
                else
                {

                    json = temp;


                    var rootOBjList = JsonConvert.DeserializeObject<List<Rootobject>>(json);
                    obj.AddRange(rootOBjList);

                    //Converting objects to csv file
                    using (var parser = new ChoCSVWriter<Rootobject>("Emp.csv").WithFirstLineHeader())
                    {
                        Console.WriteLine("Inserting into csv....");
                        parser.Write(obj);

                    }

                }
            }
        }


    }
}


