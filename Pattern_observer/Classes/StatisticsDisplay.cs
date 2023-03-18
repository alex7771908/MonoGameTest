using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_observer.Classes.Interfaces;

namespace Pattern_observer.Classes
{
    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        private float temperature;
        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[StatisticsDisplay] Temperature: {temperature}!");
            Console.ResetColor();
        }

        public void Update(float temperature, float pressure)
        {
            this.temperature = temperature;
            Display();    
        }
    }
}
