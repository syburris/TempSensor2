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
            //instantiate a temperature object
            Temperature temperature = new Temperature();

            //define the API url
            string address = "http://localhost:22002/NeuLogAPI?GetSensorValue:[Temperature],[1]";

            //intitiate the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);


            //capture the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            //write the status code to the console if it's 200
            Console.WriteLine(response.StatusCode);

            //write the JSON string to the console
            


            
        }
       
        
    }
}

