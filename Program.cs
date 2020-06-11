using System;
using System.Timers;
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
using System.Threading;

namespace TempSensor2
{
    class Program
    {
        private static System.Timers.Timer aTimer;

        static void Main(string[] args)
        {
            Console.WriteLine("Beginning experiment...");

            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");

            /*
            //define the API url
            string url = "http://localhost:22002/NeuLogAPI?GetSensorValue:[Temperature],[1]";

            //intitiate the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";

            //capture the response
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
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
            */
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
    }
}

