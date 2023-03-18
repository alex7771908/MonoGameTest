using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_observer.Classes.Interfaces
{
    /// <summary>
    /// Объект. Он наблюдает.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// При изменении состояния субъекта вызывается автоматически
        /// </summary>
        void Update(float temperature, float pressure);
    }
}
