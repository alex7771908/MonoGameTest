using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_observer.Classes.Interfaces;

namespace Pattern_observer.Classes
{
    public class PressureDisplay: IObserver, IDisplayElement
    {
        private float pressure;
        public void Display()
        {
            Console.WriteLine($"[PressureDisplay] Pressure: {pressure}!");
        }

        public void Update(float temperature, float pressure)
        {
            this.pressure = pressure;
            Display();    
        }
    }
}
