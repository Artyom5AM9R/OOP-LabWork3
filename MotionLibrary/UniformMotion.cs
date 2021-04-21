using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionLibrary
{
    /// <summary>
    /// Класс для описания равномерного движения объектов
    /// </summary>
    public class UniformMotion : MotionBase
    {
        /// <summary>
        /// Метод для определения координаты нахождения объекта
        /// </summary>
        /// <returns>Значение типа double, округленное до 2 знаков после запятой</returns>
        public override double CalculateCoordinate()
        {
            Coordinate = Speed * Time;

            return Coordinate;
        }
    }
}
