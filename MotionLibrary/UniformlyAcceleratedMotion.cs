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
    public class UniformlyAcceleratedMotion : Motion
    {
        /// <summary>
        /// Свойство для доступа к данным о начальной координате нахождения объекта
        /// </summary>
        public float StartCoordinate { get; set; }

        public float StartSpeed
        {
            get
            {
                return StartSpeed;
            }
            set
            {
                if (value > 0 && value <= 299792458)
                {
                    StartSpeed = value;
                }
            }
        }

        public float Acceleration
        {
            get
            {
                return Acceleration;
            }
            set
            {
                if (value != 0 && value <= 299792458)
                {
                    Acceleration = value;
                }
            }
        }

        /// <summary>
        /// Метод для определения координаты нахождения объекта
        /// </summary>
        /// <returns>Значение типа float</returns>
        public override float CalculateCoordinate()
        {
            Coordinate = StartCoordinate + StartSpeed * Time +
                + (Acceleration * Time * Time) / 2;

            return Coordinate;
        }

        /// <summary>
        /// Метод для определения ускорения объекта
        /// </summary>
        /// <returns></returns>
        public float CalculateAcceleration()
        {
            Acceleration = (Speed - StartSpeed) / Time;

            return Acceleration;
        }
    }
}
