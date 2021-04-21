using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionLibrary
{
    /// <summary>
    /// Класс для описания равноускоренного движения объектов
    /// </summary>
    public class AcceleratedMotion : Motion
    {
        private double _startSpeed;

        private double _acceleration;

        /// <summary>
        /// Свойство для доступа к данным о начальной координате нахождения объекта
        /// </summary>
        public double StartCoordinate{ get; set; }

        public double StartSpeed
        {
            get
            {
                return _startSpeed;
            }
            set
            {
                if (value > 0 && value <= 299792458)
                {
                    _startSpeed = value;
                }
                else
                {
                    throw new Exception("Введено некорректное значение.");
                }
            }
        }

        public double Acceleration
        {
            get
            {
                return _acceleration;
            }
            set
            {
                if (value != 0 && value <= 299792458)
                {
                    _acceleration = value;
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
        public override double CalculateCoordinate()
        {
            Coordinate = StartCoordinate + StartSpeed * Time + Acceleration * Time * Time / 2;

            return Coordinate;
        }

        /// <summary>
        /// Метод для определения ускорения объекта
        /// </summary>
        /// <returns></returns>
        public double CalculateAcceleration()
        {
            Acceleration = (Speed - StartSpeed) / Time;

            return Acceleration;
        }
    }
}
