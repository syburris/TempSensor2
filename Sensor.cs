using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
{
  "GetSensorValue":[72.8]
  
}
*/

namespace TempSensor2
{
    class Sensor
    {
        public double[] GetSensorValue { get; private set; }

        public Sensor()
        {

        }

        public Sensor(double values)
        {
            GetSensorValue = new double[(int)values];
        }
        
    }
}
