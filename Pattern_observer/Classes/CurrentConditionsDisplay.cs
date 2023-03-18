using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_observer.Classes.Interfaces;

namespace Pattern_observer.Classes
{
    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float temperature;
        private float pressure;
        public void Display()
        {
            Console.WriteLine($"[CurrentConditionsDisplay] Temperature: {temperature}  Pressure: {pressure}!");
        }

        public void Update(float temperature, float pressure)
        {
            this.temperature = temperature;
            this.pressure = pressure;
            Display();
        }
    }
}
