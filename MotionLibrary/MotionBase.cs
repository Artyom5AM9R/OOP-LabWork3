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
    public abstract class MotionBase
    {
        /// <summary>
        /// Координата положения тела
        /// </summary>
        private double _coordinate;

        /// <summary>
        /// Скорость движения тела
        /// </summary>
        private double _speed;

        /// <summary>
        /// Время движения тела
        /// </summary>
        private double _time;

        /// <summary>
        /// Максимально возможная скорость тела
        /// </summary>
        public const int MaxSpeed = 299792458;

        /// <summary>
        /// Свойство для доступа к данным о координате нахождения объекта.
        /// Значение координаты округляется до 2-х знаков после запятой.
        /// </summary>
        public double Coordinate
        {
            get
            {
                return _coordinate;
            }
            protected set
            {
                _coordinate = Math.Round(value, 2);
            }
        }

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
//TODO: const +++
                if (value > 0 && value <= MaxSpeed)
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

//TODO: Подумать о возврате значения +++
        /// <summary>
        /// Метод для определения координаты нахождения объекта с записью 
        /// полученного значения в поле _coordinate
        /// </summary>
        public abstract void CalculateCoordinate();
    }
}
