using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern_observer.Classes;

namespace Pattern_observer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // субъект
            WeatherData data = new WeatherData();

            // наблюдатель
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay();
            CurrentConditionsDisplay display = new CurrentConditionsDisplay();
            PressureDisplay pressureDisplay = new PressureDisplay();

            data.RegisterObserver(display);
            data.RegisterObserver(statisticsDisplay);
            data.RegisterObserver(pressureDisplay); 

            Console.ReadLine(); //pause
        }
    }

}
