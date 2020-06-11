using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace TempSensor2
{
    class Program
    {

        static void Main(string[] args)
        {

            //define the API url
            string url = "http://localhost:22002/NeuLogAPI?GetSensorValue:[Temperature],[1]";

            //intitiate the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";


            //capture the response
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            //write the status code to the console if it's 200
            Console.WriteLine(response.StatusCode);
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                //Console.WriteLine(reader.ReadToEnd());
                string json = reader.ReadToEnd();
                Sensor sensor = JsonConvert.DeserializeObject<Sensor>(json);
                foreach (var value in sensor.GetSensorValue)
                {
                    Console.WriteLine("The sensor is reading " + value.ToString() + "°F");
                }
            }
        }
    }
}

