using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_observer.Classes.Interfaces
{
    /// <summary>
    /// Элемент дисплэй с информацией
    /// </summary>
    public interface IDisplayElement
    {
        /// <summary>
        /// Вывод информации на основе получанных данных
        /// </summary>
        void Display();
    }
}
