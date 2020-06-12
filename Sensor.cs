
namespace TempSensor2
{

    //Sensor Object
    class Sensor
    {
        public double[] GetSensorValue { get; set; }

        public Sensor()
        {

        }

        public Sensor(double values)
        {
            GetSensorValue = new double[(int)values];
        }
        
    }
}
