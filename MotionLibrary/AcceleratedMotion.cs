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
    public class AcceleratedMotion : MotionBase
    {
        /// <summary>
        /// Ускорение тела
        /// </summary>
        private double _acceleration;

        /// <summary>
        /// Свойство для доступа к данным о начальной координате нахождения объекта
        /// </summary>
        public double StartCoordinate{ get; set; }


        /// <summary>
        /// Свойство для доступа к данным об ускорении тела
        /// </summary>
        public double Acceleration
        {
            get
            {
                return _acceleration;
            }
            set
            {
//TODO: const +++
                if (value != 0 && Math.Abs(value) <= MaxSpeed)
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
        /// Метод для определения координаты нахождения объекта с записью 
        /// полученного значения в поле _coordinate
        /// </summary>
        public override void CalculateCoordinate()
        {
            Coordinate = StartCoordinate + Speed * Time + Acceleration * Math.Pow(Time, 2) / 2;
        }
    }
}
