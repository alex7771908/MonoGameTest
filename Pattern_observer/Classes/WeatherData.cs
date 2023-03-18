using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Pattern_observer.Classes.Interfaces;

namespace Pattern_observer.Classes
{
    /// <summary>
    /// Субъект подключенный к датчикам погоды
    /// </summary>
    public class WeatherData : ISubject
    {
        private float temperature = 0;
        private float pressure = 0;
        private List<IObserver> observers = new List<IObserver>();
        public WeatherData()
        {
            Thread thread = new Thread(Start);
            thread.Start();
        }
        public void NotifyObserver()
        {
            foreach(IObserver observer in observers)
            {
                observer.Update(temperature, pressure);
            }
        }

        public void Start()
        {
            while (true)
            {
                Random random = new Random();
                int time = random.Next(1000, 4000);

                Thread.Sleep(time);

                float prevTemp = temperature;
                float prevPressure = pressure;

                temperature = random.Next(10, 21);
                pressure = random.Next(730, 790);

                if(temperature == prevTemp)
                {
                    temperature++;
                }
                if (pressure == prevPressure)
                {
                    pressure++;
                }

                NotifyObserver();
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
