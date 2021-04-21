using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionLibrary
{
    /// <summary>
    /// Класс для описания механического движения объектов
    /// </summary>
    public abstract class Motion
    {
        /// <summary>
        /// Свойство для доступа к данным о координате нахождения объекта
        /// </summary>
        public float Coordinate { get; protected set; }

        /// <summary>
        /// Свойство для доступа к данным о скорости движения объекта
        /// </summary>
        public float Speed
        {
            get
            {
                return Speed;
            }
            protected set
            {
                if (value > 0 && value <= 299792458)
                {
                    Speed = value;
                }
            }
        }

        /// <summary>
        /// Свойство для доступа к данным о времени движения объекта
        /// </summary>
        public float Time
        {
            get
            {
                return Time;
            }
            protected set
            {
                if (value > 0)
                {
                    Time = value;
                }
            }
        }

        /// <summary>
        /// Метод для определения координаты нахождения объекта
        /// </summary>
        /// <returns>Значение типа float</returns>
        public abstract float CalculateCoordinate();
    }
}
