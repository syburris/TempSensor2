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
                Console.WriteLine(json);
                Sensor sensor = JsonConvert.DeserializeObject<Sensor>(json);
                }
           
            /*
            // lets see if the Sensor Class is working
            Sensor sensor = new Sensor();
            double[] values = { 73.8, 74 };
            sensor.GetSensorValue = values;
            Array.ForEach(sensor.GetSensorValue, Console.WriteLine);

            // lets try and parse a json string into a sensor object
            string json = @"{
                'GetSensorValue':[72.8]
            }";
            Sensor sensor1 = JsonConvert.DeserializeObject<Sensor>(json);
            Console.WriteLine(sensor1.GetSensorValue[0]); //should output 72.8

            //attempt to parse strJson
            string strJson = response.ToString();
            Console.WriteLine(strJson);
            //Sensor sensor2 = JsonConvert.DeserializeObject<Sensor>(strJson);
            //Console.WriteLine(sensor2.GetSensorValue[0]); //should display temperature in degrees Fahrenheit on line after 72.8
            */




        }


    }
}

