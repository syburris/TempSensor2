using System;
using System.Timers;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using CsvHelper;
using System.Globalization;

namespace TempSensor2
{
    class Program
    {
        public static string folder = "C:\\Users\\steve\\Desktop\\FTO\\{0}.csv";
        private static System.Timers.Timer aTimer;
        public static string url = "http://localhost:22002/NeuLogAPI?GetSensorValue:[Temperature],[1]";
        public static List<Reading> readings = new List<Reading>();

        static void Main(string[] args)
        {

            Console.WriteLine("What is the sample name?");
            string file = Console.ReadLine();
            string path = string.Format(folder, file);
            Console.WriteLine("Beginning experiment...");
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            SetTimer();
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
            Console.WriteLine("A total of " + readings.Count.ToString() + " readings were taken");
            Console.WriteLine("The 2nd reading was " + readings[1].temp.ToString() + "°F");
            Console.WriteLine("It was taken at " + readings[1].time.ToString());
            GenerateReport(readings, path);
        }

        private static void SetTimer()
        {
            // Create a timer with a one second interval.
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
            //intitiate the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";

            //capture the response
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string json = reader.ReadToEnd();
                Sensor sensor = JsonConvert.DeserializeObject<Sensor>(json);
                LogReading(sensor);
            }
        }


        private static void LogReading(Sensor s)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            Reading r = new Reading();
            foreach (var value in s.GetSensorValue)
            {
                r.temp = value.ToString();
            }
            r.time = DateTime.Now.ToString();
            readings.Add(r);
        }

        //Generate the report
        private static void GenerateReport(List<Reading> list, String path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(readings);
            }
        }
    }
}

