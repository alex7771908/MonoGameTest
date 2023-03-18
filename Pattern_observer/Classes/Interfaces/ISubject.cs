using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_observer.Classes.Interfaces
{
    /// <summary>
    /// Субъект. За ним наблюдают.
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// Регистрирует наблюдателя.
        /// </summary>
        /// <param name="observer">Наблюдатель</param>
        void RegisterObserver(IObserver observer);
        /// <summary>
        /// Убирает наблюдателя.
        /// </summary>
        /// <param name="observer">Наблюдатель</param>
        void RemoveObserver(IObserver observer);
        /// <summary>
        /// Оповещает всех наблюдателей об изменениях.
        /// </summary>
        void NotifyObserver();
    }
}
