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
        public double Coordinate { get; protected set; }

        private double _speed;
        private double _time;

        /// <summary>
        /// Свойство для доступа к данным о скорости движения объекта
        /// </summary>
        public double Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                if (value > 0 && value <= 299792458)
                {
                    _speed = value;
                }
                else
                {
                    throw new Exception("Введено некорректное значение.");
                }
            }
        }

        /// <summary>
        /// Свойство для доступа к данным о времени движения объекта
        /// </summary>
        public double Time
        {
            get
            {
                return _time;
            }
            set
            {
                if (value > 0)
                {
                    _time = value;
                }
                else
                {
                    throw new Exception("Введено некорректное значение.");
                }
            }
        }

        /// <summary>
        /// Метод для определения координаты нахождения объекта
        /// </summary>
        /// <returns>Значение типа float</returns>
        public abstract double CalculateCoordinate();
    }
}
